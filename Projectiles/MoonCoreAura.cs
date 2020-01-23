using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace MoreAuras.Projectiles
{
    class MoonCoreAura : AuraModProjectile
    {
        float offsetRadius = 0;
        float offsetRadius2 = 0;
        bool offsetPlus = true;
        bool offsetPlus2 = true;
        bool myRandIsSet = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mooncore");
            if (!myRandIsSet)
            {
                offsetRadius = new Random().Next(0, 1000) / 450;
                offsetRadius2 = new Random().Next(0, 1000) / 450;
                myRandIsSet = true;
            }
        }

        public override void AI()
        {


            Player center = Main.player[(int)projectile.ai[0]];
            projectile.friendly = true;
            projectile.ai[1] += 2f * (float)Math.PI / (600f ) * projectile.localAI[1];
            projectile.ai[1] %= 2f * (float)Math.PI;
            projectile.rotation -= 2f * (float)Math.PI / 1500f * projectile.localAI[1];
            projectile.Center = center.Center + projectile.localAI[0] * new Vector2((float)Math.Cos(projectile.ai[1]) + offsetRadius, (float)Math.Sin(projectile.ai[1] + offsetRadius2 ));
            if (offsetPlus)
            {
                offsetRadius += 0.015f;
                if (offsetRadius >= 0.700f)
                {
                    offsetPlus = false;
                }
            }
            if(!offsetPlus)
            {
                offsetRadius -= 0.015f;
                if (offsetRadius <= -0.700f)
                {
                    offsetPlus = true;
                }
            }

            if (offsetPlus2)
            {
                offsetRadius2 += 0.015f;
                if (offsetRadius2 >= 0.700f)
                {
                    offsetPlus2 = false;
                }
            }
            if (!offsetPlus2)
            {
                offsetRadius2 -= 0.015f;
                if (offsetRadius2 <= -0.700f)
                {
                    offsetPlus2 = true;
                }
            }
        }

        public override string Texture => mod.Name + "/Items/MoonCore";
    }
}
