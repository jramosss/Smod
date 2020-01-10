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
            AdvancedRecipe recipe = new AdvancedRecipe(mod,ModContent.NPCType<Npcs.Town.Git>());
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.MuySukii>());
            recipe.AddIngredient(ItemID.LunarBar,15);
            recipe.AddTile(TileID.LunarCraftingStation); //wouldn´t it be cool if i make my own tile?
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}