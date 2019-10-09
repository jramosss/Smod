using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Smod.Items.Weapons {
    public class TrueEraser : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("True Eraser");
            Tooltip.SetDefault("Like the Eraser,... but true!");
        }
        public override void SetDefaults() {
            item.damage = 100;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.useTime = 25;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.noMelee = true;
            item.width = 40;
			item.height = 40;
            item.knockBack = 0;
            item.rare = 3;
            item.autoReuse = true;
        }
        public override void UseStyle(Player player) {
            bool in_screen = true;
            for (int i = 0; i < 200; i++) {
                in_screen = Main.npc[i].position.X <= Main.screenWidth + Main.screenPosition.X
                            && Main.npc[i].position.Y <= Main.screenHeight  + Main.screenPosition.Y
                            && Main.npc[i].position.X >= Main.screenPosition.X
                            && Main.npc[i].position.Y >= Main.screenPosition.Y;
                if (!Main.npc[i].townNPC && Main.npc[i].active && !Main.npc[i].friendly && !Main.npc[i].dontTakeDamage && !Main.npc[i].immortal && in_screen) {
                    Main.npc[i].StrikeNPC(200,0,0);
                }
            }
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Eraser"));
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}