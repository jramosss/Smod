using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Smod.Projectiles;
using Smod.Items.Weapons;

namespace Smod.Items.Weapons {
    public class MuySukii : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("MuySukiStaff");
            Tooltip.SetDefault("Muy Sukiiii");
        }
        public override void SetDefaults() {
            item.damage = 15;
            item.useAnimation = 40;
            item.useStyle = 1;
            item.useTime = 40;
            item.UseSound = SoundID.Item1; //Crear un sonido SUKII
            item.magic = true;
            item.noMelee = true;
            item.width = 40;
			item.height = 40;
            item.knockBack = 0;
            item.rare = 3;
            item.mana = Main.LocalPlayer.statMana-(Main.LocalPlayer.statMana/4);
            item.autoReuse = false;
            item.shoot = ProjectileType<Torna2>();
        }
        /*public override void UseStyle(Player player) {
            Meterle alguna textura al tornado o algo como para q se note q estoy apretando
        }*/
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar,20);
            recipe.AddIngredient(ItemType<SukiStaff>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}