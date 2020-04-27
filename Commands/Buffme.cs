using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Smod.Commands {
    public class Buffme : ModCommand {
        public override CommandType Type
			=> CommandType.World;

		public override string Command
			=> "buffme";

		public override string Usage
			=> "buffme buff time";

		public override string Description
			=> "Buffs the player for each task combat/mining/clears";

        public override void Action(CommandCaller caller, string input, string[] args) {
            Player player = new Player();
            player = Main.LocalPlayer;
            int time;
            if(args[1] == null) time = 999999;
            else time = int.Parse(args[1]);
            switch(args[0]){
                case "mining":
                    player.AddBuff(BuffID.Mining,time);
                    player.AddBuff(BuffID.Spelunker,time);
                    player.AddBuff(BuffID.Shine,time);
                    break;
                case "combat":
                    player.AddBuff(BuffID.Regeneration,time);
                    player.AddBuff(BuffID.Swiftness,time);
                    player.AddBuff(BuffID.WellFed,time);
                    player.AddBuff(BuffID.Wrath,time);
                    player.AddBuff(BuffID.Inferno,time);
                    player.AddBuff(BuffID.Honey,time);
                    player.AddBuff(BuffID.Heartreach,time);
                    player.AddBuff(BuffID.HeartLamp,time);
                    player.AddBuff(BuffID.Campfire,time);
                    break;
                case "ranged":
                    player.AddBuff(BuffID.AmmoBox,time);
                    player.AddBuff(BuffID.Rage,time);
                    goto case "combat";
                case "summoner":
                    player.AddBuff(BuffID.Summoning,time);
                    break;
                case "mage":
                    player.AddBuff(BuffID.MagicPower,time);
                    player.AddBuff(BuffID.Clairvoyance,time);
                    break;
                case "all":
                    var help = new Helpers();
                    help.GiveAllBuffs(Main.LocalPlayer);
                    goto case "summoner";
                case "saiyan":
                    player.AddBuff(ModContent.BuffType<Buffs.UltraInstinct>(),9999);
                    break;
                case "clear":
                    for (int i = player.buffType.Length - 1; i >= 0; i--) {
                        Main.LocalPlayer.DelBuff(i);
                    }
                    break;
            }
        }
    }
}