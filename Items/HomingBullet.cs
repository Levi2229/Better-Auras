using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoreAuras.Items
{
    class HomingBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("It's trying to fly away as you're holding it.. strange");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.accessory = true;
            item.value = Item.sellPrice(platinum: 5);
            item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AuraPlayer>().homingBullet.isActive = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<GhastlyRock>(), 1);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 40);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
