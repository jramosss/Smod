using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Smod.Projectiles;

namespace Smod.Items.Weapons {
    public class Skr : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Exponential Shooter");
            Tooltip.SetDefault("Yells a weird word");
        }
        public override void SetDefaults() {
            item.damage = 50;
            item.width = 30;
            item.height = 30;
            item.mana = 10;
            item.knockBack = 1;
            item.melee = false;
            item.noMelee = true;
            item.magic = true;
            item.useAnimation = 2;
            item.useTime = 12;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.UseSound = SoundID.Item10; // TODO: Sound
            item.value = 20000;
            item.rare = 2;
            item.autoReuse = true;
            item.shoot = ProjectileType<Orbs>();
            item.shootSpeed = 10;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CoinGun,1);
            recipe.AddIngredient(ItemID.ShadowbeamStaff,1);
            recipe.AddIngredient(ItemID.AdamantiteBar,10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}