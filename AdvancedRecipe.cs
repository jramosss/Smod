using Terraria;
using Terraria.ModLoader;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Smod {
    public class AdvancedRecipe : ModRecipe {
        public int neededNPC;
        public bool inAir = false;
        private const int range = 32*16;
        public AdvancedRecipe (Mod mod, int NeededNPC) : base(mod){
            neededNPC = NeededNPC;
        }
        public override bool RecipeAvailable() {
            bool foundNPC = false;
            //int npc = ModContent.NPCType<Npcs.Town.Git>();
            var npc = Main.npc.Any(n => n.active && n.type == ModContent.NPCType<Npcs.Town.Git>());
            if(!NPC.downedMoonlord || Main.LocalPlayer.velocity.Y != 0){
                return false;
            }
            if (npc.active && npc.type == neededNPC){
                if (Vector2.Distance(Main.LocalPlayer.Center, npc.Center) <= range)
                    foundNPC = true;
                }
            return foundNPC;
        }
        public override void OnCraft(Item item) {
            Main.LocalPlayer.AddBuff(ModContent.BuffType<Buffs.TheLord>(),500);
        }
    }
}