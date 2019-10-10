using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using Microsoft.Xna.Framework;

namespace Smod.Npcs.Bosses {
    public class Haskell : ModNPC {
        private int difficulty {
            get {
                int result = 0;
                if (Main.expertMode) {result++;}
                if (NPC.downedMoonlord) {result++;}
                return result;
            }
        }
        private float attackCool {
			get => npc.ai[0];
			set => npc.ai[0] = value;
		}
        private float moveCool {
			get => npc.ai[1];
			set => npc.ai[1] = value;
		}

		private float rotationSpeed {
			get => npc.ai[2];
			set => npc.ai[2] = value;
		}

		private float captiveRotation {
			get => npc.ai[3];
			set => npc.ai[3] = value;
		}
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Haskell, Devil´s Speaker");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults() {
			npc.aiStyle = -1;
			npc.lifeMax = 35000;
			npc.damage = 100;
			npc.defense = 55;
			npc.knockBackResist = 0f;
			npc.width = 75;
			npc.height = 75;
			npc.value = Item.buyPrice(0, 10, 0, 0);
			npc.npcSlots = 15f;
			npc.boss = true;
			npc.lavaImmune = true;
			//npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.buffImmune[24] = true;
			music = MusicID.Boss2;
		}
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}
        public override void AI(){
            Player player = Main.LocalPlayer;
            bool outOfRange = Math.Abs(npc.position.X - player.position.X) > 50;
            if (Main.netMode == 0) {
                if (!player.active || player.dead || outOfRange){
                    npc.TargetClosest(false);
                    npc.velocity = new Vector2(0f, 10f);
					if (npc.timeLeft > 10) {
						npc.timeLeft = 10;
					}
					return;
				}
            }
        }
    }
}



