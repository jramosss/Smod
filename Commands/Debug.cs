using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Linq;

namespace Smod.Commands {
    public class Debug : ModCommand {
        public override CommandType Type
			=> CommandType.World;

		public override string Command
			=> "debug";

		public override string Usage
			=> "debug args";

		public override string Description
			=> "debugger";
        public override void Action(CommandCaller caller, string input, string[] args) {
            Player player = Main.LocalPlayer;
            switch(args[0]) {
                case "sss":
                    //bool luminite = player.inventory.FirstOrDefault(i => i.type == ItemID.LumarBar);
                    bool luminite = player.HasItem(ItemID.LunarBar);
                    bool mss = player.HasItem(ModContent.ItemType<Items.Weapons.MuySukii>());
                    bool in_air = player.velocity.Y != 0;
                    bool moonlord = NPC.downedMoonlord;
                    bool Git = Main.npc.Any(n => n.active && n.type == ModContent.NPCType<Npcs.Town.Git>() && Main.LocalPlayer.Distance(n.Center) <= 32*16);
                    bool all = luminite && in_air && mss && moonlord && Git;
                    if(!all){
                        Main.NewText("U dont meet all the requirements");
                        if(luminite) {
                            Main.NewText("U do have the luminite");
                        }
                        if (mss) {
                            Main.NewText("U have the MuySukiStaff");
                        }
                        if (in_air) {
                            Main.NewText("U are in air");
                        }
                        if (Git) {
                            Main.NewText("Git is near");
                        }
                        if (moonlord) {
                            Main.NewText("Downed Moonlord");
                        }
                    }
                    else {
                        Main.NewText("U meet all the requirements");
                    }
                    break;
                case "git":
                    Main.NewText("Town NPCS: " + Main.LocalPlayer.townNPCs);
                    Main.NewText("Player has cellphone: " + Main.LocalPlayer.HasItem(ItemID.CellPhone));
                    Main.NewText("Player has UltraShark: " + Main.LocalPlayer.HasItem(ModContent.ItemType<Items.Weapons.UltraShark>()));
                    break;
                case "direction":
                    Main.NewText("Player direction: " + player.direction);
                    break;
                case "velocityx":
                    Main.NewText("Player Velocity X: " + player.velocity.X);
                    break;
                case "velocityy":
                    Main.NewText("Player Velocity Y: " + player.velocity.Y);
                    break;
            }
        }
    }
}
