/* 
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Smod.Items.Tools {
    public class AxeRose : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Axe Rose");
            Tooltip.SetDefault("Cuts all trees in screen");
        }
        public override void SetDefaults() {
            item.damage = 70;
            item.axe = 100;
            item.melee = true;
            item.noMelee = false;
            item.UseSound = SoundID.Item1;
            item.useStyle = 1;
            item.useAnimation = 15;
            item.width = 40;
            item.height = 40;
            item.knockBack = 6;
            item.value = 30000;
            item.rare = 3;
            item.autoReuse = true;
        }
        // No recipe, i will make it droppeable from my future npcs
        public override void MeleeEffects(Player player, Microsoft.Xna.Framework.Rectangle hitbox) {
            bool inScreen = true;
            while (inScreen) {
                WorldGen.KillTile()
            }
        }
    }
}
*/