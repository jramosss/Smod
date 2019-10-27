using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Smod.Commands {
    public class ShowStat : ModCommand {
        public override CommandType Type => CommandType.World;
        public override string Usage => "ShowStat stat";
        public override string Description => "Show the value of the given stat";
        public override string Command => "Showstat";
        public override void Action(CommandCaller caller, string input, string[] args) {
            Player player = Main.LocalPlayer;
            switch (args[0]) {
                case "liferegen":
                    Main.NewText(player.lifeRegen);
                    break;
                case "movespeed":
                    Main.NewText(player.moveSpeed);
                    break;
                case "miningspeed":
                    Main.NewText(player.pickSpeed);
                    break;
                case "dps":
                    Main.NewText(player.dpsDamage);
                    break;
            } // TODO: Add more cases
        }
    }
}