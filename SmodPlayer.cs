/* 
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Smod {
    public class SmodPlayer : ModPlayer {
        bool HolyFeets;

        public override void ResetEffects() {
            Player player = Main.LocalPlayer;
            if (player.HasItem(mod.ItemType("Holy Feet"))){
                HolyFeets = false;
            }
        }
        /* 
        public override void UpdateLifeRegen() {
            Player player = Main.LocalPlayer;
            //Idea: Hacer que el jugador se cure cuando pise tierra santa usando el accesorio "Pies santos"
            if (player.TouchedTiles.Contains(mod.ItemType("Holy Dirt")))

        }
        public override void PreUpdateBuffs() {
            
        }
    }
}
*/