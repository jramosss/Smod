using Terraria;
using Terraria.ModLoader;

namespace Smod.Commands {
    public class Clear : ModCommand {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "clear";

        public override string Usage => "clear";

        public override string Description => "Clears the chat";

        public override void Action(CommandCaller caller, string input, string[] args) {
            for (int i = 0; i < 9; i++) {
                Main.NewText(" ");
            }
        }
    }
}