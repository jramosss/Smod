using Terraria.ID;
using Terraria.ModLoader;

namespace Smod.Items.Weapons
{
	public class GreedySword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("GreedySword");
			Tooltip.SetDefault("Sharp as C#, Greedy as fuck");
		}
		public override void SetDefaults()
		{
			item.damage = 400;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 1;
			item.knockBack = 15;
			item.value = 40000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.FragmentVortex, 15);
			recipe.AddIngredient(ItemID.FragmentSolar, 15);
			recipe.AddIngredient(ItemID.FragmentStardust, 15);
			recipe.AddIngredient(ItemID.FragmentNebula, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
