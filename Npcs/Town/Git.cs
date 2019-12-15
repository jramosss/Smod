using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
			Player player = Main.LocalPlayer;
            if (player.HasItem(mod.ItemType("UltraShark")) || player.HasItem(ItemID.CellPhone) && player.activeNPCs >= 12) {
                return true;
            }
            return false;
        }
        /*If someday i want to implement histerical housing conditions for my NPC 
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
        //public override void FindFrame(int frameHeight) {}
        public override string GetChat() {
			int Cyborg = NPC.FindFirstNPC(NPCID.Cyborg);
			if (Cyborg > 0 && Main.rand.NextBool(4)) {
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
						Main.npcChatCornerItem = ModContent.ItemType<Items.Weapons.UltraShark>() ;
						return $"Hey, if you craft a [i:{ModContent.ItemType<Items.Weapons.UltraShark>()}], I can upgrade it for you. Wait, where did i hear that b4?";
					}
				default:
					return "Dont make me angry, or i´ll delete all ur commits!";
			}
		}
        public override void SetChatButtons(ref string button, ref string button2) {
			button = Language.GetTextValue("LegacyInterface.28");
			button2 = "Awesomeify";
			if (Main.LocalPlayer.HasItem(ModContent.ItemType<Items.Weapons.UltraShark>())) {
				button = "Upgrade " + Lang.GetItemNameValue(ModContent.ItemType<Items.Weapons.UltraShark>());
			}
		}
		public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			if (firstButton) {
				// We want 3 different functionalities for chat buttons, so we use HasItem to change button 1 between a shop and upgrade action.
				if (Main.LocalPlayer.HasItem(ModContent.ItemType<Items.Weapons.UltraShark>())) {
					Main.PlaySound(SoundID.Item37); // Reforge/Anvil sound
					Main.npcChatText = $"I upgraded your {Lang.GetItemNameValue(ModContent.ItemType<Items.Weapons.UltraShark>())} to a Supreme Shark";
					int UltraSharkItemIndex = Main.LocalPlayer.FindItem(ModContent.ItemType<Items.Weapons.UltraShark>());
					Main.LocalPlayer.inventory[UltraSharkItemIndex].TurnToAir();
					Main.LocalPlayer.QuickSpawnItem(ModContent.ItemType<Items.Weapons.SupremeShark>());
					return;
				}
				shop = true;
			}
			else {
				// If the 2nd button is pressed, open the inventory...
				Main.playerInventory = true;
				// remove the chat window...
				Main.npcChatText = "";
				// and start an instance of our UIState.
				//GetInstance<ExampleMod>().ExamplePersonUserInterface.SetState(new UI.ExamplePersonUI());
				// Note that even though we remove the chat window, Main.LocalPlayer.talkNPC will still be set correctly and we are still technically chatting with the npc.
			}
		}
		public override void SetupShop(Chest shop, ref int nextSlot) {
			shop.item[nextSlot].SetDefaults(ItemType<Items.Weapons.HighCallibreBullet>());
			nextSlot++;
			//Will add more stuff when i have more stuff.
		}
		public override void NPCLoot() {
			var exampleModAsoc = ModLoader.GetMod("Examplemod");
			if (exampleModAsoc != null) {
				Item.NewItem(npc.getRect(), exampleModAsoc.ItemType("Exampleblock"));
			}
			else {
				Item.NewItem(npc.getRect(), ItemID.MartianConduitPlating, 200);
			}
		}
		public override bool CanGoToStatue(bool toKingStatue) {return false;}
		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 5;
			knockback = 1f;
		}
		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 10;
			randExtraCooldown = 5;
		}
		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ModContent.ProjectileType<Projectiles.Torna2>(); // TODO : Create a custom projectile for Giiit
			attackDelay = 1;
		}
		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 18f;
			randomOffset = 2f;
		}
    }
}