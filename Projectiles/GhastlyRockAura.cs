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
    class GhastlyRockAura : AuraModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ghastly Rock");
        }

        public override void AI()
        {
            Player center = Main.player[(int)projectile.ai[0]];
            projectile.friendly = true;
            projectile.ai[1] += 2f * (float)Math.PI / 600f * projectile.localAI[1];
            projectile.ai[1] %= 2f * (float)Math.PI;
            projectile.rotation -= 2f * (float)Math.PI / 120f * projectile.localAI[1];
            projectile.Center = center.Center + projectile.localAI[0] * new Vector2((float)Math.Cos(projectile.ai[1]), (float)Math.Sin(projectile.ai[1]));
        }

        public override string Texture => mod.Name + "/Projectiles/GhastlyRockAura";
    }
}
