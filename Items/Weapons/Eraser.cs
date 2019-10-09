using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Smod.Items.Weapons {
    public class Eraser : ModItem {
        // La idea seria una espada que al ser usada, mate a todo lo que esta en la pantalla, los extraños de discord me dijeron que haga esto
        /* 
        screen's position is Main.screenPosition
    anything that's within that position + Main.screenWidth or Main.screenHeight is on-screen
    
    you iterate over Main.npc and damage everything that intersects with the screen range
    you usually make a Rectangle centered around your player
    with width/height set to Main.screenWidth and Main.screenHeight
    npc.StrikeNPC is used to damage things
 */
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Eraser Sword");
            Tooltip.SetDefault("Extremely OP");
        }
        public override void SetDefaults() {
            item.damage = 100;
            item.useAnimation = 12;
            item.useStyle = 1;
            item.useTime = 12;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.noMelee = true;
            item.width = 40;
			item.height = 40;
            item.knockBack = 0;
            item.rare = 3;
            item.autoReuse = true;
        }
        float yThreshold = 2*16; //Threshold of 1 tiles vertically up/down

        public static void someone_died (Player player) {
            for (int i = 0; i < 200; i++) {
                if (Main.npc[i].life < Main.npc[i].lifeMax) {
                    Main.NewText("Someone Died!");
                }
            }
        }
        public override void UseStyle(Player player){
            int do_nothing = 0;
            bool in_screen = true;
            float yDifference = 0f;
            for(int i = 0; i < 200; i++){
                yDifference = Math.Abs(Main.npc[i].position.Y - player.position.Y);
                in_screen = Main.npc[i].position.X <= Main.screenWidth + Main.screenPosition.X
                            && Main.npc[i].position.Y <= Main.screenHeight  + Main.screenPosition.Y
                            && Main.npc[i].position.X >= Main.screenPosition.X
                            && Main.npc[i].position.Y >= Main.screenPosition.Y;
                if (yDifference < yThreshold && !Main.npc[i].townNPC && Main.npc[i].active && !Main.npc[i].friendly && !Main.npc[i].dontTakeDamage && !Main.npc[i].immortal && in_screen) {
                    if (player.direction == 1 && Main.npc[i].position.X > player.position.X) {// 1 = right, -1 = left
                        Main.npc[i].StrikeNPC(100,0,0);
                        //someone_died(player); //DEBUG
                    }
                    else if (player.direction == 1 && !(Main.npc[i].position.X < player.position.X)){
                        do_nothing++;
                        //someone_died(player);
                    }
                    else if (player.direction == -1 && Main.npc[i].position.X < player.position.X) {
                        Main.npc[i].StrikeNPC(100,0,0);
                        //someone_died(player);
                    }
                    else {
                        do_nothing++;
                        //someone_died(player);
                    }
                }
            }
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TerraBlade);
            recipe.AddIngredient(ItemID.AdamantiteBar,10);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}