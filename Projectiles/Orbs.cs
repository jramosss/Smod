using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
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
			projectile.hostile = true;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = false;
		}
        public override void AI(){
            bool onScreen = this.projectile.position.X < Main.screenWidth - this.projectile.position.X;
            int n = 0;
            while(onScreen) {
                this.projectile.velocity.X += (float)Math.Pow(2,n) - 0.5f;
                n++;
            }
        }
    }
}