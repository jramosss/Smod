using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Smod.Items.Potions {
    public class Saiyan : ModItem {
        public override void SetStaticDefaults () {
            DisplayName.SetDefault("Saiyan");
            Tooltip.SetDefault("4 Minutes Duration \nMakes u feel like u snorted 3 lines of cocaine");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = 4;
            item.value = Item.buyPrice(gold: 4);
            item.buffType = ModContent.BuffType<Buffs.UltraInstinct>(); //Specify an existing buff to be applied when used.
            item.buffTime = 14400; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar,3);
            recipe.AddIngredient(ItemID.HerbBag,10);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}