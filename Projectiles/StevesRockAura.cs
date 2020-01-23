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
    class StevesRockAura : AuraModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steve's Rock");
            offsetSpeedSlightly();
        }

        public override string Texture => mod.Name + "/Items/StevesRock";

    }
}
