using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Smod.Commands {
    public class Clearinv : ModCommand {
        public override CommandType Type
			=> CommandType.World;

		public override string Command
			=> "clearinv";

		public override string Usage
			=> "clearinv";

		public override string Description
			=> "Clears the inventory, except the fav items and the first layer";

        public override void Action(CommandCaller caller, string input, string[] args) {
            for (int i = 10; i < Main.LocalPlayer.inventory.Length; i++) {
                if (!Main.LocalPlayer.inventory[i].favorited) {
                    Main.LocalPlayer.inventory[i].TurnToAir();
                }
            }
        }
    }
}