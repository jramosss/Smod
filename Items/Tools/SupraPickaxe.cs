using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Smod.Items.Tools {
    public class SupraPickaxe : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Supra Pickaxe");
            Tooltip.SetDefault("Faster than curso de fotografia release");
        }
        public override void SetDefaults() {
            item.melee = true;
            item.noMelee = false;
            item.damage = 40;
            item.knockBack = 2;
            item.rare = 1;
            item.pick = 325;
            item.useTime = 3;
            item.useAnimation = 5;
            item.width = 40;
			item.height = 40;
            item.useStyle = 1;
            item.value = 20000;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
        }
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddRecipeGroup("Smod:LunarPickaxes");
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void MeleeEffects(Player player, Microsoft.Xna.Framework.Rectangle hitbox) {
            if (Main.rand.NextBool(200)){
                player.AddBuff(BuffID.Mining,300);
            }
        }
    }
}