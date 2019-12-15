using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace Smod {
    public class Helpers {
        public bool in_screen (NPC npc){
            return npc.position.X <= Main.screenWidth + Main.screenPosition.X
                   && npc.position.Y <= Main.screenHeight  + Main.screenPosition.Y
                   && npc.position.X >= Main.screenPosition.X
                   && npc.position.Y >= Main.screenPosition.Y;
        }
    }
}