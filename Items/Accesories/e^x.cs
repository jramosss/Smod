using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;

namespace Smod.Items.Accesories {
    public class ExponentialBoots : ModItem {
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("e^x");
            Tooltip.SetDefault("Exponential boots increases player damage\nbasing on his movespeed");
        }
        public override void SetDefaults() {
            item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = Item.sellPrice(platinum: 2);
			item.rare = ItemRarityID.Blue;
        }
        private float maxRunSpeedIncrease = 0f;
        private float maxRunSpeedIncreasePerSecond = 5f;
        public override void UpdateAccessory(Player player, bool hideVisual){
            if(Math.Abs(player.velocity.X) > 0f){
                maxRunSpeedIncrease += maxRunSpeedIncreasePerSecond / 60f;
            }
            else {
                maxRunSpeedIncrease = 0f;
            }
            player.maxRunSpeed += maxRunSpeedIncrease;
            player.allDamage += player.maxRunSpeed*1.5f;
        }
        public override void AddRecipes(){
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostsparkBoots);
            recipe.AddIngredient(ItemID.ChlorophyteBar,10); //Add a more original recipe
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
