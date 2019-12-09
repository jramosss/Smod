using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Smod.Items.Weapons {
    public class SukiStaff: ModItem {
        //La idea seria que haga como un tornadito que atraiga npcs (aspero), tambien hacerle mejoras cosa de que el tornado sea mas fuerte, habia q ver 
        // si le meto daño o no
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("SukiStaff");
            Tooltip.SetDefault("Sukiiii");
        }
        public override void SetDefaults() {
            item.damage = 0;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.useTime = 25;
            item.UseSound = SoundID.Item1; //Crear un sonido SUKII
            item.magic = true;
            item.noMelee = true;
            item.width = 40;
			item.height = 40;
            item.knockBack = 0;
            item.rare = 3;
            item.autoReuse = false;
        }
        public override void UseStyle(Player player) {
            bool in_screen = true;
            Vector2 TornadoPos = Main.MouseWorld;
            for (int i = 0; i < 200; i++) {
                in_screen = Main.npc[i].position.X <= Main.screenWidth + Main.screenPosition.X
                            && Main.npc[i].position.Y <= Main.screenHeight  + Main.screenPosition.Y
                            && Main.npc[i].position.X >= Main.screenPosition.X
                            && Main.npc[i].position.Y >= Main.screenPosition.Y;
                if (in_screen){
                    Main.npc[i].position.X = TornadoPos.X;
                    Main.npc[i].position.Y = TornadoPos.Y;
                }
            }
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar,20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
