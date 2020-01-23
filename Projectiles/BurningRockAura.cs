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
    class BurningRockAura : AuraModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Burning Rock");
        }

        public override string Texture => mod.Name + "/Items/BurningRock";


    }
}
