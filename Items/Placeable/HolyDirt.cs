using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace Smod.Items.Placeable {
    public class HolyDirtt : ModItem {
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Healer Dirt");
        }
        public override void SetDefaults() {
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = TileType<Tiles.HolyDirt>();
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock,25);
            recipe.AddIngredient(ItemID.HolyWater,1);
            //recipe.AddTile() TODO: Create a holy altar as a tile for making this kind of things
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}