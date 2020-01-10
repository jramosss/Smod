using Terraria;
using Terraria.ModLoader;
using System.Linq;

namespace Smod {
    public class AdvancedRecipe : ModRecipe {
        public int neededNPC;
        public bool inAir = false;
        private const int range = 32*16;
        public AdvancedRecipe (Mod mod, int NeededNPC) : base(mod){
            neededNPC = NeededNPC;
        }
        public override bool RecipeAvailable() {
            return NPC.downedMoonlord && Main.LocalPlayer.velocity.Y != 0 
                   && Main.npc.Any(n => n.active && n.type == ModContent.NPCType<Npcs.Town.Git>() 
                   && Main.LocalPlayer.Distance(n.Center) <= range);
        }
        public override void OnCraft(Item item) {
            Main.LocalPlayer.AddBuff(ModContent.BuffType<Buffs.TheLord>(),500);
        }
    }
}