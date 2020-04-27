using Terraria;

namespace Smod {
    public class Helpers {
        public bool in_screen (NPC npc){
            return npc.position.X <= Main.screenWidth + Main.screenPosition.X
                   && npc.position.Y <= Main.screenHeight  + Main.screenPosition.Y
                   && npc.position.X >= Main.screenPosition.X
                   && npc.position.Y >= Main.screenPosition.Y;
        }
        public void GiveAllBuffs(Player player,int time = 99999) {
            for (int i = 1; i < 200; i++) {
                player.AddBuff(i,time);
            }
        }
    }
}