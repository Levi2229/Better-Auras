using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MoreAuras.Values;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace MoreAuras.Projectiles
{

    abstract class AuraModProjectile : ModProjectile
    {
        public string name;
        public string texturePath;
        public float speed;
        public int amount;
        public float speedX = 0;
        public float speedY = 0;
        public int damage;
        public int knockback;
        public bool isActive = false;
        public List<int> instanceIds = new List<int>();
        Random random = new Random();
        float rnd;

        public override void SetDefaults()
        {
            projectile.width = 48;
            projectile.height = 48;
            projectile.penetrate = -1;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 999999999;
            projectile.ignoreWater = true;
            projectile.netImportant = true;
            rnd = (float)random.NextDouble();
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(projectile.localAI[0]);
            writer.Write(projectile.localAI[1]);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            projectile.localAI[0] = reader.ReadSingle();
            projectile.localAI[1] = reader.ReadSingle();
        }

        public override void AI()
        {
            Player center = Main.player[(int)projectile.ai[0]];
            projectile.friendly = true;
            projectile.ai[1] += 2f * (float)Math.PI / 600f * projectile.localAI[1];
            projectile.ai[1] %= 2f * (float)Math.PI;
            projectile.Center = center.Center + projectile.localAI[0] * new Vector2((float)Math.Cos(projectile.ai[1]), (float)Math.Sin(projectile.ai[1]));
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White * ((255 - projectile.alpha) / 255f);
        }

        public void offsetSpeedSlightly()
        {
            Random random = new Random();
            speed += (float)random.NextDouble();
        }
    }
}
