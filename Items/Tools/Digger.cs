//IDEA: Make a hole from surface to hell
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using static Terraria.ModLoader.ModContent;

namespace Smod.Items.Tools
{
    public class Digger : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Digger");
            Tooltip.SetDefault("Digs a hole");
        }
        public override void SetDefaults() {
            item.damage = 0;
            item.noMelee = true;
            item.knockBack = 0;
            item.rare = 1;
            item.useTime = 10;
            item.useAnimation = 5;
            item.width = 40;
			item.height = 40;
            item.useStyle = 1;
            item.value = 20000;
            item.UseSound = SoundID.Item1;
			item.autoReuse = false;
        }
        public override bool UseItem(Player player){
            Vector2 mouse = new Vector2();
            GlobalTile tile = new GlobalTile();
            mouse = Main.MouseWorld;
            List<Tuple<float,float>> set = new List<Tuple<float,float>>(); //player.ZoneUnderworldHeight
            for(float i = mouse.Y; i > Main.maxTilesY - 200;i--) {
                for(float j = mouse.X; j < mouse.X+1;j++) {
                    set.Add(new Tuple<float,float>(i,j));
                }
            }
            foreach(Tuple<float,float> tup in set) {
                tile.Dangersense((int)tup.Item1,(int)tup.Item2,TileType<>(),player);
            }
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltPickaxe);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}