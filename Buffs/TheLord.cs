using Terraria;
using Terraria.ModLoader;

namespace Smod.Buffs {
    public class TheLord : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("The Lord");
            Description.SetDefault("You rule this game!");
            Main.debuff[Type] = false;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
			canBeCleared = false;
            Main.time = 750000;
        }
        public override void Update(NPC npc, ref int buffIndex) {
            Helpers helpers = new Helpers();
            helpers.GiveAllBuffs(Main.LocalPlayer);
        }
    }
}