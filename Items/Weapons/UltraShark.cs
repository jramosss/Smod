using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Smod.Items.Weapons{
    public class UltraShark : ModItem{
        public override void SetStaticDefaults () {
            DisplayName.SetDefault("UltraShark");
            Tooltip.SetDefault("The double upgraded version of minishark");
        }

        public override void SetDefaults() {
            item.damage = 45;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shoot = AmmoID.Bullet;
            item.useTime = 4;
            item.width = 25;
            item.height = 25;
            item.UseSound = SoundID.Item11;
            item.ranged = true;
            item.noMelee = true;
            item.value = 30000;
            item.rare = 1;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar,20);
            recipe.AddIngredient(ItemID.Megashark,1);
            recipe.AddIngredient(ItemID.IceBlock,250);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool ConsumeAmmo(Player player)
		{
            //Main.NewText("Ammo not consumed");  Just for debugging
			return Main.rand.NextFloat() >= .50f;
		}
    }
}