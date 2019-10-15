using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Smod {
    public class SmodPlayer : ModPlayer {
        bool HolyFeets;

        public override void ResetEffects() {
            HolyFeets = false;
        }
        
    }
}