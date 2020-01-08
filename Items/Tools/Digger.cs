//IDEA: Make a hole from surface to hell
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Smod.Items.Tools
{
    public class Digger : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Digger");
            Tooltip.SetDefault("Digs a hole");
        }
        public override void SetDefaults() {
            item.damage = 0;
            item.noMelee = true;
            item.knockBack = 0;
            item.rare = 1;
            item.useTime = 10;
            item.useAnimation = 5;
            item.width = 40;
			item.height = 40;
            item.useStyle = 1;
            item.value = 20000;
            item.UseSound = SoundID.Item1;
			item.autoReuse = false;
        }
        public override bool UseItem(Player player){
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltPickaxe);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}