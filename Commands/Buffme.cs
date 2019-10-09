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
			=> "buffme args";

		public override string Description
			=> "Buffs the player for each task combat/mining/clears";

        public override void Action(CommandCaller caller, string input, string[] args) {
            Player player = new Player();
            player = Main.LocalPlayer;
            switch(args[0]){
                case "mining":
                    player.AddBuff(BuffID.Mining,40000);
                    player.AddBuff(BuffID.Spelunker,40000);
                    player.AddBuff(BuffID.Shine,40000);
                    break;
                case "combat":
                    player.AddBuff(BuffID.Regeneration,40000);
                    player.AddBuff(BuffID.Swiftness,40000);
                    player.AddBuff(BuffID.WellFed,40000);
                    player.AddBuff(BuffID.Wrath,40000);
                    player.AddBuff(BuffID.Inferno,40000);
                    player.AddBuff(BuffID.Honey,40000);
                    player.AddBuff(BuffID.Heartreach,40000);
                    player.AddBuff(BuffID.HeartLamp,40000);
                    player.AddBuff(BuffID.Campfire,40000);
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