using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Smod.Projectiles;

namespace Smod.Items.Weapons {
    public class SuperSukii : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("SSS");
            Tooltip.SetDefault("Super Sukiiii Staff");
        }
        public override void SetDefaults() {
            item.damage = 30;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.useTime = 30;
            item.UseSound = SoundID.Item1; //Crear un sonido SUKII
            item.magic = true;
            item.noMelee = true;
            item.width = 40;
			item.height = 40;
            item.knockBack = 0;
            item.rare = 3;
            item.mana = Main.LocalPlayer.statMana;
            item.autoReuse = false;
            item.shoot = ProjectileType<Torna3>();
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar,20);
            recipe.AddIngredient(ItemType<MuySukii>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}