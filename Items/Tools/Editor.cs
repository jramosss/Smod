using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Smod.Items.Tools {
    public class Editor : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Editor");
            Tooltip.SetDefault("Select area to modify");
        }
        public override void SetDefaults() {
            item.damage = 0;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.useTime = 10;
            //item.UseSound = SoundID.Item1; //Crear un sonido SUKII
            item.magic = true;
            item.noMelee = true;
            item.width = 40;
			item.height = 40;
            item.knockBack = 0;
            item.rare = 3;
            item.mana = 0;
            item.autoReuse = false;
        }

        private static short MaxX (Point16 first,Point16 second) {
            if (first.X > second.X || first.X == second.X)
                return first.X;
            return second.X;
        }

        private static short MaxY (Point16 first,Point16 second) {
            if (first.Y > second.Y || first.Y == second.Y)
                return first.Y;
            return second.X;
        }

        bool firstuse = true;
        bool done = false;
        public override bool UseItem(Player player) {

            Point16 firstPos = Main.MouseWorld.ToTileCoordinates16();
            Point16 secondPos = firstPos;
            done = false;
            
            Main.NewText("First Use: " + firstuse + "\n");

            Main.NewText("First Pos" + firstPos + "\n");

            Main.NewText("Second Pos" + secondPos + "\n");

            if (firstuse) {
                firstPos = Main.MouseWorld.ToTileCoordinates16();
                secondPos = firstPos;
                firstuse = false;
            }
            else {
                secondPos = Main.MouseWorld.ToTileCoordinates16();
                done = true;
            }
            if (done){
                //Tile edit;
                short maxX = MaxX(firstPos,secondPos);
                short maxY = MaxY(firstPos,secondPos);

                for(int i = maxX - 1; i > 0; i--){
                    for (int j = maxY - 1; j > 0; j--) {
                        Framing.GetTileSafely(i,j).ClearTile();
                        //edit.ClearEverything()
                    }
                }
            }
            
            return true;
        }
        public override void UseStyle(Player player) {
            int totalTime = PlayerHooks.TotalUseTime(item.useTime, player, item);
            if (player.itemTime == totalTime / 2) {
                if (!firstuse && done) {
                    firstuse = true;
                }
            }
        }
    }
}