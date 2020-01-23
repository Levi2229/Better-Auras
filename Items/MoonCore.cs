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
    class MoonCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Ripped out from straight from the chest, it reminds you of the tough battle.");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 41;
            item.accessory = true;
            item.value = Item.sellPrice(platinum: 4);
            item.rare = ItemRarityID.Orange;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AuraPlayer>().moonCore.isActive = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<GhastlyRock>(), 1);
            recipe.AddIngredient(ItemID.LunarBar, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
