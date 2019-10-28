using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Smod;
using Terraria.DataStructures;
namespace Smod {
    public class SmodPlayer : ModPlayer {
        public bool HolyGrace = true;

        public override void ResetEffects() {
            HolyGrace = false;
        }
        public override void UpdateLifeRegen() {
            Player player = Main.LocalPlayer;
            Tile tile;
            foreach(Point coord in player.TouchedTiles){
                tile = Main.tile[coord.X, coord.Y];
                if(tile.type == ModContent.TileType<Tiles.HolyDirt>() && HolyGrace /*player.HasItem(ModContent.ItemType<Items.Accesories.HolyFeet>()) && player.HasItem(mod.ItemType("HolyFeet")))*/) {
                    //player.AddBuff(ModContent.BuffType<Buffs.HolyGrace>(),100);
                    player.lifeRegen += 6;
                    Main.NewText("Healing"); // Debug
                }
            }
        }
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) {
            player.respawnTimer = 180;
            base.Kill(damage, hitDirection, pvp, damageSource);
        }
    }
        namespace Items.Accesories {
            internal class HolyFeet : ModItem {
                public override void SetDefaults() {
                    item.width = 34;
                    item.height = 34;
                    item.accessory = true;
                    item.value = 40000;
                    item.rare = 5;
                }
                public override void UpdateAccessory(Player player, bool hideVisual) {
                    player.GetModPlayer<SmodPlayer>().HolyGrace = true;
                }
                public override void Update(ref float gravity, ref float maxFallSpeed) {
                    Player player = Main.LocalPlayer;
                    player.GetModPlayer<SmodPlayer>().HolyGrace = true;
                }
            }
        }
}