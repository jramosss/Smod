using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Smod {
    public class SmodPlayer : ModPlayer {
        bool HolyFeets;

        public override void ResetEffects() {
            Player player = Main.LocalPlayer;
            if (!player.HasItem(mod.ItemType("Holy Feet"))){
                HolyFeets = false;
            }
            else {
                HolyFeets = true;
            }
        }
        public override void UpdateLifeRegen() {
            Player player = Main.LocalPlayer;
            //Idea: Hacer que el jugador se cure cuando pise tierra santa usando el accesorio "Pies santos"
            //Go over each coordinate
            /* 
            if (player.HasItem(ModContent.ItemType<Items.Accesories.HolyFeets>())) {
                Main.NewText("Have holy feet");
                Tile tile;
                foreach(Point coord in player.TouchedTiles){
                    //Then get the tile at that coordinate
                    tile = Main.tile[coord.X, coord.Y];
                    if(tile.type == ModContent.TileType<Tiles.HolyDirt>()){  //Assuming that Holy Dirt's class name is "HolyDirt" and in the "MyMod.Tiles" namespace
                        player.lifeRegen += 4;                               //Also, always use the XType<class>() variant instead of XType(string).  it's faster                                                                        //Do things with this Tile
                        Main.NewText("Healing"); // Debug
                    }
                }
            }
            */
            foreach(Point coord in player.TouchedTiles){
                //Then get the tile at that coordinate
                Tile tile;
                tile = Main.tile[coord.X, coord.Y];
                if(tile.type == ModContent.TileType<Tiles.HolyDirt>() && player.HasItem(ModContent.ItemType<Items.Accesories.HolyFeets>())){  //Assuming that Holy Dirt's class name is "HolyDirt" and in the "MyMod.Tiles" namespace
                    player.lifeRegen += 4;                               //Also, always use the XType<class>() variant instead of XType(string).  it's faster                                                                        //Do things with this Tile
                    Main.NewText("Healing"); // Debug
                }
            }
        }
        /* 
        public override void PreUpdateBuffs() {
            
        }
        */
    }
}