/* 
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Smod.Items.Weapons {
    public class Bombarda : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Bombarda!");
            Tooltip.SetDefault("Just dont thow it into ur house, unless...");
            base.SetDefaults();
        }
        public override void SetDefaults() {
			item.useStyle = 1;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType<Projectiles.ExampleExplosive>();
			item.width = 8;
			item.height = 28;
			item.maxStack = 30;
			item.consumable = true;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 40;
			item.useTime = 40;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.rare = 3;
		}
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Grenade,15);
			recipe.AddIngredient(ItemID.GoldPickaxe);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this,5);
			recipe.AddRecipe();
		}
    }
}
*/