using Terraria;
using Terraria.ModLoader;
using System;

namespace Smod.Projectiles {
    public class Orbs : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Orb");
        }

        public override void SetDefaults() {
			projectile.width = 30;
			projectile.height = 30;
			projectile.alpha = 0;
			projectile.timeLeft = 600;
			projectile.penetrate = -1;
			projectile.hostile = false;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
            projectile.friendly = true;
            projectile.direction = Main.LocalPlayer.direction;
		}
        public override bool OnTileCollide(Microsoft.Xna.Framework.Vector2 oldVelocity) {
            this.projectile.Kill(); // Dunno why it ignore tiles anyway
            return true;
        }

        public float globalAcc = 0;

        public float Accelerate (int timeLeft) {
            if (timeLeft == 600) {
                globalAcc += 0.01f;
            }

            else if (timeLeft < 600 && timeLeft > 500) {
                globalAcc += 0.08f;
            }

            else if (timeLeft < 500 && timeLeft > 400) {
                globalAcc += 0.5f;
            }

            else if (timeLeft < 30) {
                globalAcc = 0f;
            }

            else {
                globalAcc += 0.9f;
            }

            return globalAcc;
        }

        public override void AI() {
            if (projectile.velocity.X > 0) {
                projectile.velocity.X = Accelerate(projectile.timeLeft);
            }
            else {
                projectile.velocity.X = -(Accelerate(projectile.timeLeft));
            }
            // Main.NewText("Speed: " + projectile.velocity.X); DEBUG
            projectile.velocity.Y = 0f;
        }

        /* 
        Tried to reinvent the wheel, ended bad
        public override void AI(){
            bool onScreen = projectile.position.X >= Main.screenPosition.X
                 && projectile.position.X <= Main.screenPosition.X + Main.screenWidth
                 && projectile.position.Y >= Main.screenPosition.Y
                 && projectile.position.Y <= Main.screenPosition.Y + Main.screenHeight;
            int n = 0;
            while(onScreen) {
                Main.NewText("Into the loop");
                projectile.velocity.X += (float)Math.Pow(2,n) - 0.5f;
                projectile.velocity.Y += (float)Math.Pow(2,n) - 0.5f;
                n++;
                onScreen = projectile.position.X >= Main.screenPosition.X
                           && projectile.position.X <= Main.screenPosition.X + Main.screenWidth
                           && projectile.position.Y >= Main.screenPosition.Y
                           && projectile.position.Y <= Main.screenPosition.Y + Main.screenHeight;
                //DEBUG
                Main.NewText("X: " + projectile.position.X);
                Main.NewText("Y: " + projectile.position.Y);
            }
        }
        */
    }
}