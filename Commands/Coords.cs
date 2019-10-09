using Terraria;
using Terraria.ModLoader;

namespace Smod.Commands {
    public class Coords : ModCommand {
        public override CommandType Type => CommandType.World;
        public override string Command => "coords";
        public override string Usage => "coords";
        public override void Action(CommandCaller caller, string input, string[] args) {
            Player player = Main.LocalPlayer;
            Main.NewText("X = " + player.position.X);
            Main.NewText("Y = " + player.position.Y);
        }
    }
}