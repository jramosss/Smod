using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Smod.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace Smod.Items.Weapons {
    public class SukiStaff: ModItem {
        //La idea seria que haga como un tornadito que atraiga npcs (aspero), tambien hacerle mejoras cosa de que el tornado sea mas fuerte, habia q ver 
        // si le meto daño o no
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("SukiStaff");
            Tooltip.SetDefault("Sukiiii");
        }
        public override void SetDefaults() {
            item.damage = 1;
            item.useAnimation = 50;
            item.useStyle = 1;
            item.useTime = 50;
            item.UseSound = SoundID.Item1; //Crear un sonido SUKII
            item.magic = true;
            item.noMelee = true;
            item.width = 40;
			item.height = 40;
            item.knockBack = 0;
            item.rare = 3;
            item.mana = 10;
            item.autoReuse = false;
            item.shoot = ProjectileType<Tornado>();
        }
        /*public override void UseStyle(Player player) {
            Meterle alguna textura al tornado o algo como para q se note q estoy apretando
        }*/
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar,20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
