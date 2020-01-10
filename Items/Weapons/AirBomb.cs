using Terraria;
using Terraria.ModLoader;
using System;
using Terraria.ID;
using Smod.Projectiles;

namespace Smod.Items.Weapons {
    public class AirBomb : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("AirBomb");
            Tooltip.SetDefault("Try it, fun AF");
        }
        public override void SetDefaults() {
            item.useStyle = 1;
			item.shootSpeed = 12f;
			item.shoot = ModContent.ProjectileType<Projectiles.AirPulse>();
			item.width = 8;
			item.height = 28;
			item.maxStack = 999;
			item.consumable = true;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 40;
			item.useTime = 40;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.rare = 3;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Grenade);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}