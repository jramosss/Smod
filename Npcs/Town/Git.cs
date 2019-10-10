using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Smod.Npcs.Town {
    public class Git : ModNPC {
        public Player player = Main.LocalPlayer;

        public override string Texture => "Smod/Npcs/Town/Git";

		public override string[] AltTextures => new[] { "Smod/Npcs/Town/Git_Alt_1" };

		public override bool Autoload(ref string name) {
			name = "Git";
			return mod.Properties.Autoload;
		}
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Git!");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
        }
        public override void SetDefaults() {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 1;
			npc.defense = 30;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 1f;
			animationType = NPCID.Guide;
		}
        public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++) {
				Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("Sparkle"));
			}
		}
        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            if (player.HasItem(mod.ItemType("UltraShark")) || player.HasItem(ItemID.CellPhone)) {
                return true;
            }
            return false;
        }
        /* If someday i want to implement histerical housing conditions for my NPC 
        public override bool CheckConditions(int left, int right, int top, int bottom) {
			int score = 0;
			for (int x = left; x <= right; x++) {
				for (int y = top; y <= bottom; y++) {
					int type = Main.tile[x, y].type;
					if (type == mod.TileType("ExampleBlock") || type == mod.TileType("ExampleChair") || type == mod.TileType("ExampleWorkbench") || type == mod.TileType("ExampleBed") || type == mod.TileType("ExampleDoorOpen") || type == mod.TileType("ExampleDoorClosed")) {
						score++;
					}
					if (Main.tile[x, y].wall == mod.WallType("ExampleWall")) {
						score++;
					}
				}
			}
			return score >= (right - left) * (bottom - top) / 2;
		}
        */
        public override string TownNPCName() {
			switch (WorldGen.genRand.Next(4)) {
				case 0:
					return "Gitty";
				case 1:
					return "Gitter";
				case 2:
					return "Gitt";
				default:
					return "Giiiiiiiiit";
			}
		}
        public override void FindFrame(int frameHeight) {}
        public override string GetChat() {
			int Cyborg = NPC.FindFirstNPC(NPCID.Cyborg);
			if (Cyborg >= 0 && Main.rand.NextBool(4)) {
				return "I find " + Main.npc[Cyborg].GivenName + " very atractive, dunno why";
			} 
			switch (Main.rand.Next(4)) {
				case 0:
					return "I can remember any move that u do!";
				case 1:
					return "I´m the pet of an evil corporation!";
				case 2:
					{
						// Main.npcChatCornerItem shows a single item in the corner, like the Angler Quest chat.
						Main.npcChatCornerItem = ItemID.HiveBackpack;
						return $"Hey, if you find a [i:{ItemID.HiveBackpack}], I can upgrade it for you. Wait, where did i hear that?";
					}
				default:
					return "Dont make me angry, or u will regret it!";
			}
		}
        public override void SetChatButtons(ref string button, ref string button2) {
			button = Language.GetTextValue("LegacyInterface.28");
			button2 = "Awesomeify";
			if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
				button = "Upgrade " + Lang.GetItemNameValue(ItemID.HiveBackpack);
		}
    }
}