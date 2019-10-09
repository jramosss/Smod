using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Smod.Items.Weapons {
    public class HighCallibreBullet : ModItem {
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("High Calibre Bullet");
            Tooltip.SetDefault("Big and Heavy as ur mother");
        }

        public override void SetDefaults() {
            item.damage = 20;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 9999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.2f;
			item.value = 10;
			item.rare = 2;
			item.shoot = ProjectileID.BulletHighVelocity;   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 18f;                  //The speed of the projectile
			item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Feather,1);
            recipe.AddIngredient(ItemID.MusketBall,300);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this,150);
            recipe.AddRecipe();
        }

        public override void OnConsumeAmmo(Player player) {
            if (Main.rand.NextBool(5)){
                player.AddBuff(BuffID.Swiftness,300);
            }
        }
     }
}