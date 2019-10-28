using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Smod.Commands {
    public class AxelRose : ModCommand {
        public override CommandType Type => CommandType.World;
        public override string Usage => "axelrose";
        public override string Description => "Just like Axel Rose did";
        public override string Command => "axelrose";
        public override void Action(CommandCaller caller, string input, string[] args) {
            Main.LocalPlayer.KillMe(Terraria.DataStructures.PlayerDeathReason.LegacyDefault(),1000,1);
        }
    }
}