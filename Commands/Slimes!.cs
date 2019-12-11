using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;

namespace Smod.Commands {
    public class Slimes : ModCommand {
        public override CommandType Type => CommandType.World;
        public override string Usage => "/slimes ammount";
        public override string Command => "slimes";
        public override string Description => "Spawns as many slimes as u want";
        public override void Action(CommandCaller caller, string input, string[] args) {
            int pos = 5;
            for  (int i = 0; i < int.Parse(args[0]); i++) {
                NPC.NewNPC((int)Main.LocalPlayer.Center.X+pos,(int)Main.LocalPlayer.Center.Y,NPCID.GreenSlime);
                pos = (int)Math.Pow(-1,i)*pos;
                if (pos > 0) pos+= 7;
                else pos-=7;
            }
        }
    }
}