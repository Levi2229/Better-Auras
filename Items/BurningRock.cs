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
    class BurningRock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("It's warmth is constantly present");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 50);
            item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AuraPlayer>().burningRock.isActive = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<VileRock>(), 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 15);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
