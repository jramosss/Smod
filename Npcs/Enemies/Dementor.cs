using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;

namespace Smod.Npcs.Enemies {
    public class Dementor : ModNPC {
        public override void NPCLoot() {
            /* 
            if (Main.rand.NextBool(70)){
                Add a super weird item, probably a wand that is very useful to defeat MY boss
            }
            */
            //else {
                if (Main.rand.NextBool(5)){
                    Item.NewItem(npc.getRect(), ItemID.Obsidian);
                }
            //}
        }
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Flutter Slime"); // Automatic from .lang files
			Main.npcFrameCount[npc.type] = 6; // make sure to set this for your modnpcs.
		}

		public override void SetDefaults() {
			npc.width = 32;
			npc.height = 32;
			npc.aiStyle = -1; // This npc has a completely unique AI, so we set this to -1.
			npc.damage = 14;
			npc.defense = 7;
			npc.lifeMax = 40;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			//npc.alpha = 175;
			//npc.color = new Color(0, 80, 255, 100);
			npc.value = 25f;
			npc.buffImmune[BuffID.Frostburn] = true;
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return 3.4f;
		}
        

    }
}
