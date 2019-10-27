using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Smod.Buffs {
    public class HolyGrace : ModBuff {
        public override void SetDefaults() {
			DisplayName.SetDefault("Holy Grace");
			Description.SetDefault("The holy grace is healing you");
			Main.debuff[Type] = false;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			canBeCleared = false;
		}
        public override void Update(NPC npc, ref int buffIndex) {
            Player player = Main.LocalPlayer;
            player.lifeRegen += 6;
        }
    }
}