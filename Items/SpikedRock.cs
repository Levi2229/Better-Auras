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
    class SpikedRock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("It's a rock, with spikes!");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.accessory = true;
            item.value = Item.sellPrice(silver: 1);
            item.rare = ItemRarityID.Blue;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AuraPlayer>().spikedRock.isActive = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<StevesRock>(), 1);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipeAlt = new ModRecipe(mod);
            recipeAlt.AddIngredient(ItemType<StevesRock>(), 1);
            recipeAlt.AddIngredient(ItemID.LeadBar, 10);
            recipeAlt.AddTile(TileID.Anvils);
            recipeAlt.SetResult(this);
            recipeAlt.AddRecipe();
        }
    }
}
