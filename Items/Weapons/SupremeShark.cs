using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Smod.Items.Weapons {
    public class SupremeShark : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Supreme Shark");
            Tooltip.SetDefault("U wont find anything more powerful than this\n50% chance to not consume ammo\n0,005% chance to become invincible");
        }
        public override void SetDefaults() {
            item.damage = 75; //OP
            item.width = 34;
            item.height = 34;
            item.useTime = 4;
            item.useAnimation = 4;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.UseSound = SoundID.Item11;
            item.ranged = true;
            item.noMelee = true;
            item.value = 30000;
            item.rare = 1;
            item.autoReuse = true;
            item.shoot = 8;
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Bullet; // Maybe in the future i make a projectile
        }
        public override bool ConsumeAmmo(Player player) {
            return Main.rand.NextFloat() >= .50f;
        }
    }
}