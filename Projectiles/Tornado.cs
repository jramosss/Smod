using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;
namespace Smod.Projectiles
{
    public class Tornado : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Tornado Balls");
        }
        public override void SetDefaults() {
            projectile.width = 50;
			projectile.height = 90;
			projectile.alpha = 0;
			projectile.timeLeft = 650;
			projectile.penetrate = -1;
			projectile.hostile = false;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
            projectile.friendly = true;
            projectile.direction = (int)Main.MouseWorld.X;
            projectile.position = Main.MouseWorld;
        }
        private List<Tuple<int,int>> id_and_damage = new List<Tuple<int,int>>();
        public override void Kill(int timeLeft) {
            foreach (NPC npc in Main.npc) {
                foreach (Tuple<int,int> tuple in id_and_damage) {
                    if (npc.whoAmI == tuple.Item1){
                        npc.damage = tuple.Item2;
                    }
                }
            }
        }
        public override void AI() {
            Helpers inscr = new Helpers();
            foreach (NPC npc in Main.npc) {
                if(inscr.in_screen(npc) && npc.CanBeChasedBy(projectile) && !npc.boss && npc.damage > 0) {
                    npc.velocity += npc.DirectionTo(projectile.Center)*2.5f; //TODO: Hacerlo como un tornado, cosa que los npcs giren en torno al proyectil
                    id_and_damage.Add(new Tuple<int, int>(npc.whoAmI,npc.damage));
                    npc.damage = 0;
                }
            }
        }
    }
}