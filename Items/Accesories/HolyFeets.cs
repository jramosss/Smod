using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Smod.Items.Accesories {
    public class HolyFeets : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Holy Feets");
			Tooltip.SetDefault("Allows the player to get healed if he walks on Holy Dirt.");
		}
        public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 30);
			item.rare = ItemRarityID.Blue;
		}
		
    }
}