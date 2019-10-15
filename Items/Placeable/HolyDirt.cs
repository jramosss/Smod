using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
//TODO: textura
namespace Smod.Items.Placeable {
    public class HolyDirt : ModItem {
        public override void SetStaticDefaults() {
			Tooltip.SetDefault("This is a modded block.");
			ItemID.Sets.ExtractinatorMode[item.type] = item.type;
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
			//item.createTile = mod.TileType("ExampleBlock");
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock,30);
            recipe.AddIngredient(ItemID.HolyWater,1);
            //Por ahora lo dejo sin ningun tile, pero en el futuro, quiero hacer un "santuario" para bendecir la tierra
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}