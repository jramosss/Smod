using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Smod.Tiles {
    public class HolyDirt : ModTile {
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
		}
		public override void ChangeWaterfallStyle(ref int style) {
			style = mod.GetWaterfallStyleSlot("ExampleWaterfallStyle");
		}
        public override void FloorVisuals(Player player) {
			if (player.HasItem(mod.ItemType("HolyFeet"))) {
				player.lifeRegen+=2;
			}
		}
    }
}