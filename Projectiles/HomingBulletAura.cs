using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;

namespace MoreAuras.Projectiles
{
    class HomingBulletAura : AuraModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Homing bullet");
            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override void AI()
        {
            bool target = false;
            projectile.friendly = true;
            Player center = Main.player[(int)projectile.ai[0]];
            Vector2 CalcedCenter = center.Center + projectile.localAI[0] * new Vector2((float)Math.Cos(projectile.ai[1]), (float)Math.Sin(projectile.ai[1]));
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 66, 0f, 0f, 100, new Color(0, 255, 0), 1.5f);
            Main.dust[dust].velocity *= 0.1f;
            Main.dust[dust].velocity += projectile.velocity* 0.2f;
            Main.dust[dust].position.X = projectile.Center.X + (float)Main.rand.Next(-2, 3);
            Main.dust[dust].position.Y = projectile.Center.Y + (float)Main.rand.Next(-2, 3);
            Main.dust[dust].noGravity = true;
  
            float distance = 400f;
            float distanceRelativeToPlayer = 0;
            Vector2 move = Vector2.Zero;
            Vector2 oldPos = Vector2.Zero;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newMove = Main.npc[k].Center - projectile.Center;
                    oldPos = CalcedCenter - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    Vector2 positionRelativeToPlayer = center.Center - projectile.Center;
                    distanceRelativeToPlayer = (float)Math.Sqrt(positionRelativeToPlayer.X * positionRelativeToPlayer.X + positionRelativeToPlayer.Y * positionRelativeToPlayer.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target && distanceRelativeToPlayer < 400)
            {
                AdjustMagnitude(ref move);
                projectile.velocity = (10 * projectile.velocity + move) ;
                AdjustMagnitude(ref projectile.velocity);
            } else if (distanceRelativeToPlayer >= 400 && oldPos != Vector2.Zero)
            {
                AdjustMagnitude(ref oldPos);
                projectile.velocity = (10 * projectile.velocity + oldPos);
                AdjustMagnitude(ref projectile.velocity);
            }
            if ((!target && (CalcedCenter - projectile.Center).X == oldPos.X && oldPos.Y == (CalcedCenter - projectile.Center).Y) || oldPos == Vector2.Zero)
            {
                projectile.ai[1] += 2f * (float)Math.PI / 150f * projectile.localAI[1];
               
                projectile.Center = CalcedCenter;
            }
            projectile.rotation -= 2f * (float)Math.PI / 150f * projectile.localAI[1];
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 12f)
            {
                vector *= 12f / magnitude;
            }
        }

        public override string Texture => mod.Name + "/Items/HomingBullet";
    }
}
