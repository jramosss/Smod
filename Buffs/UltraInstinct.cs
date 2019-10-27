using Terraria;
using  Terraria.ModLoader;
using Terraria.ID;

namespace Smod.Buffs {
    public class UltraInstinct : ModBuff {
        public override void SetDefaults() {
			DisplayName.SetDefault("Ultra Instinct");
			Description.SetDefault("You´re using the 100% of your brain");
			Main.debuff[Type] = false;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
			canBeCleared = false;
            Main.time = 3000;
		}

        public override void Update(Player player, ref int buffIndex) {
            player = Main.LocalPlayer;
            player.AddBuff(BuffID.Mining,10000);
            player.AddBuff(BuffID.Swiftness,10000);
            player.maxRunSpeed += 2.4f;
            player.runAcceleration += 1.1f;
            player.jumpBoost = true;
            player.jumpSpeedBoost += 2.7f;
            player.AddBuff(BuffID.StardustGuardianMinion ,7000);
        }
    }
}