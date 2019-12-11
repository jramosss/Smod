using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using System;

namespace Smod.Projectiles {
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
        public override void Kill(int timeLeft) {
            bool in_screen = false;
            foreach (NPC npc in Main.npc) {
                in_screen = npc.position.X <= Main.screenWidth + Main.screenPosition.X
                            && npc.position.Y <= Main.screenHeight  + Main.screenPosition.Y
                            && npc.position.X >= Main.screenPosition.X
                            && npc.position.Y >= Main.screenPosition.Y;
                if(in_screen && npc.CanBeChasedBy(projectile) && !npc.boss) {
                    foreach (Tuple<(int,int)> tuple in id_and_damage) {
                        if (npc.type == tuple.Item1.Item1){

                        }
                    }
                }
        }
        private List<Tuple<(int,int)>> id_and_damage = new List<Tuple<(int,int)>>(); //ive made a mistake bc i created a list of tuples of tuples, but honestly
                                                                                    //i dont know how to fix it so ill work this way
        public override void AI() {
            bool in_screen = false;
            foreach (NPC npc in Main.npc) {
                in_screen = npc.position.X <= Main.screenWidth + Main.screenPosition.X
                            && npc.position.Y <= Main.screenHeight  + Main.screenPosition.Y
                            && npc.position.X >= Main.screenPosition.X
                            && npc.position.Y >= Main.screenPosition.Y;
                if(in_screen && npc.CanBeChasedBy(projectile) && !npc.boss) {
                    npc.velocity += npc.DirectionTo(projectile.Center)*1.5f; //TODO: Hacerlo como un tornado, cosa que los npcs giren en torno al proyectil
                    id_and_damage.Add(new Tuple<(int, int)>((npc.type,npc.damage)));
                    npc.damage = 0;
                }
            }
        }
    }
}