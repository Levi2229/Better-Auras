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
    class VileRock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("It horrifies you to have two of these floating around you. But they are strong");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Blue;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AuraPlayer>().vileRock.isActive = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<SpikedRock>(), 1);
            recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipeAlt = new ModRecipe(mod);
            recipeAlt.AddIngredient(ItemType<SpikedRock>(), 1);
            recipeAlt.AddIngredient(ItemID.CrimtaneBar, 10);
            recipeAlt.AddTile(TileID.DemonAltar);
            recipeAlt.SetResult(this);
            recipeAlt.AddRecipe();
        }
    }
}
