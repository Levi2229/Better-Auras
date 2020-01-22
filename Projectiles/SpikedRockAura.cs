﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace MoreAuras.Projectiles
{
    class SpikedRockAura : AuraModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spiked Rock");
        }

        public override string Texture => mod.Name + "/Projectiles/SpikedRockAura";

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawPos = projectile.Center - Main.screenPosition;
            Vector2 drawCenter = new Vector2(24f, 24f);
            for (int k = 2; k <= 24; k += 2)
            {
                float scale = 2f * k / 48f;
                spriteBatch.Draw(mod.GetTexture("Projectiles/SpikedRockAura"), drawPos, null, Color.White, 0f, drawCenter, scale, SpriteEffects.None, 0f);
            }
        }

    }
}