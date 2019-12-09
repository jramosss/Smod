using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Smod.Items.Tools {
    public class NPCInfo : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("NPCInfo");
            Tooltip.SetDefault("Displays all clicked npc info");
        }
        public override void SetDefaults() {
            item.damage = 1;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.useTime = 10;
            item.UseSound = SoundID.Item1; //Crear un sonido SUKII
            item.magic = true;
            item.noMelee = true;
            item.width = 40;
			item.height = 40;
            item.knockBack = 0;
            item.rare = 3;
            item.mana = 0;
            item.autoReuse = false;
        }
        public void DisplayInfo (int i) {
            NPC npc = Main.npc[i];
            Main.NewText(npc.GivenOrTypeName + " has " + npc.life + " HP");
            if (npc.lavaImmune){Main.NewText(npc.GivenOrTypeName + " is inmune to lava");}
            else Main.NewText(npc.GivenOrTypeName + " is not inmune to lava");
            Main.NewText(npc.GivenOrTypeName + " has " + npc.lifeMax + " Max life");
            Main.NewText("Town NPC: " + npc.townNPC);
            Main.NewText("NPC Type: " + npc.type);
            Main.NewText("NPC Type name: " + npc.TypeName);
            Main.NewText("NPC velocity: " + npc.velocity);
            Main.NewText("Boss: " + npc.boss);
            Main.NewText("X: " + npc.position.X + " Y: " + npc.position.Y);
        }
        public override bool UseItem(Player player) {
            Vector2 mousepos = Main.MouseWorld;
            NPC npc;
            //Main.NewText("X: " + mousepos.X);
            //Main.NewText("Y: " + mousepos.Y);
            for(int i = 0; i < 200; i++) {
                mousepos = Main.MouseWorld;
                npc = Main.npc[i];
                //Main.NewText("Loop running");
                if (mousepos.X >= npc.position.X && mousepos.X <= npc.position.X + npc.width && mousepos.Y >= npc.position.Y && mousepos.Y <= npc.position.Y + npc.height) {
                    DisplayInfo(i);
                }
            }
            return true;
        }
    }
}