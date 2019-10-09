using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Smod.Commands {
    public class Holocaust : ModCommand {
        public override CommandType Type => CommandType.World;
        public override string Command => "holocaust";
        public override string Usage => "holocaust";
        public override string Description => "Kill Everybody";
        public override void Action(CommandCaller caller, string input, string[] args) {
            for (int i = 0; i < 200; i++) {
                if (Main.npc[i].townNPC) {
                    Main.npc[i].StrikeNPC(900,15,1);
                }
            }
        }
    }
}