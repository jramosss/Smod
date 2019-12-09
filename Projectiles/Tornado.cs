using Terraria;
using Terraria.ModLoader;
using System;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

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
        }
        /* Go for is the function that is intended to atract the enemies to the "tornado" (projectile).
            It has 4 variables, upX, upY, downX and downY, upX and upY starts at 0 and goes to 
            projectile.position, increasing every loop iteration, downX and downY starts at 
            npc.position+projectile.position and decrease till projectile.position
            Ive made 8 cases, which represents if the npc position is "righter" 
            "lefter" "downer" "upper" than the projectile, and depending on each case, decreases
            or increases the velocity of the npc.
            In my head this works perfectly, for example, if a slime is at my right, at the same
            Y than me, its X velocity will start decreasing progressively till he reaches the
            tornado.
            Anyway, when i click with my staff, all nearby npcs automatically dissapears.*/
        public override void AI() {
            bool in_screen = false;
            foreach (NPC npc in Main.npc) {
                in_screen = npc.position.X <= Main.screenWidth + Main.screenPosition.X
                            && npc.position.Y <= Main.screenHeight  + Main.screenPosition.Y
                            && npc.position.X >= Main.screenPosition.X
                            && npc.position.Y >= Main.screenPosition.Y;
                if (in_screen && !npc.friendly && !npc.boss) {
                    npc.velocity += npc.DirectionTo(projectile.Center)*3f;
                }
            }
        }
    }
}