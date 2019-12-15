using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;
namespace Smod.Projectiles {
    public class Torna3 : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Torna3 Balls");
        }
        public override void SetDefaults() {
            projectile.width = 100;
			projectile.height = 150;
			projectile.alpha = 0;
			projectile.timeLeft = 1000;
			projectile.penetrate = -1;
			projectile.hostile = false;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
            projectile.friendly = true;
            projectile.position = Main.MouseWorld;
        }
        //ARRAY IMPLEMENTATION
        private int[] ids = new int[Main.npc.Length];
        private int[] damages = new int[Main.npc.Length];
        private int i = 0; 
        public override void AI() {
            Helpers inscr = new Helpers();
            foreach (NPC npc in Main.npc) {
                if(inscr.in_screen(npc) && npc.CanBeChasedBy(projectile) && !npc.boss) {
                    npc.velocity += npc.DirectionTo(projectile.Center)*3.5f; //TODO: Hacerlo como un tornado, cosa que los npcs giren en torno al proyectil
                    ids[i] = npc.whoAmI;
                    damages[i] = npc.damage;
                    i++;
                    npc.damage = 0;
                }
            }
        }
        public override void Kill(int timeLeft) {
            foreach (NPC npc in Main.npc) { //i wonder if it costs less memory iterate over main.npc again or calculate in_screen again, suppose the fst
                for (int j = 0; j < ids.Length; j++) {
                    if (npc.whoAmI == ids[j]){
                        npc.damage = damages[j];
                    }
                }        
            }
        }

        /* TUPLE IMPLEMENTATION
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
                            npc.damage = tuple.Item1.Item2;
                        }
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
                    npc.velocity += npc.DirectionTo(projectile.Center)*3.5f; //TODO: Hacerlo como un tornado, cosa que los npcs giren en torno al proyectil
                    id_and_damage.Add(new Tuple<(int, int)>((npc.whoAmI,npc.damage)));
                    npc.damage = 0;
                }
            }
        }
        */
    }
}