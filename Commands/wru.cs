using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Smod.Commands {
    public class Wru : ModCommand {
        public override CommandType Type => CommandType.World;
        public override string Usage => "wru args";
        public override string Command => "wru";
        public override string Description => "Tells the coordinates of some NPC";
        public override void Action(CommandCaller caller, string input, string[] args) {
            float posX = 0;
            float posY = 0;
            string name = "";
            switch(args[0]){
                case "armsdealer":
                    if (Main.npc[NPCID.ArmsDealer].active) {
                        posX = Main.npc[NPCID.ArmsDealer].position.X;
                        posY = Main.npc[NPCID.ArmsDealer].position.Y;
                        name = Main.npc[NPCID.ArmsDealer].FullName; // TODO, put names to all npcs just like this, now is too late
                    }
                    break;

                case "nurse":
                    if (Main.npc[NPCID.ArmsDealer].active)
                    posX = Main.npc[NPCID.Nurse].position.X;
                    posY = Main.npc[NPCID.Nurse].position.Y;
                    break;    
                case "dyetrader":
                    if (Main.npc[NPCID.DyeTrader].active)
                    posX = Main.npc[NPCID.DyeTrader].position.X;
                    posY = Main.npc[NPCID.DyeTrader].position.Y;
                    break;
                case "guide":
                    if (Main.npc[NPCID.Guide].active)
                    posX = Main.npc[NPCID.Guide].position.X;
                    posY = Main.npc[NPCID.Guide].position.Y;
                    break;
                case "angler":
                    if (Main.npc[NPCID.Angler].active)
                    posX = Main.npc[NPCID.Angler].position.X;
                    posY = Main.npc[NPCID.Angler].position.Y;
                    break;
                case "dryad":
                    if (Main.npc[NPCID.Dryad].active)
                    posX = Main.npc[NPCID.Dryad].position.X;
                    posY = Main.npc[NPCID.Dryad].position.Y;
                    break;
                case "stylist":
                    if (Main.npc[NPCID.Stylist].active)
                    posX = Main.npc[NPCID.Stylist].position.X;
                    posY = Main.npc[NPCID.Stylist].position.Y;
                    break;
            } // I will make more when i need it, far by now
            Main.NewText("X: " + posX);
            Main.NewText("Y: " + posY);
        }
    }
}