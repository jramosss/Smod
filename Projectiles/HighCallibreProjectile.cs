using Terraria;
using Terraria.ModLoader;

namespace Smod.Projectiles {
    public class HighCallibreProjectile : ModProjectile {
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("HighCallibreProjectile");
        }
        public override void SetDefaults() {
			projectile.width = 30;
			projectile.height = 30;
			projectile.alpha = 0;
			projectile.timeLeft = 20;
			projectile.penetrate = -1;
			projectile.hostile = false;
			projectile.ranged = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
            projectile.friendly = true;
            projectile.direction = Main.LocalPlayer.direction;
		}
        public override bool OnTileCollide(Microsoft.Xna.Framework.Vector2 oldVelocity) {
            this.projectile.Kill(); // Dunno why it ignore tiles anyway
            return true;
        }
        Player player = Main.LocalPlayer;
        public override void AI(){
            if(player.direction > 0) {
                player.velocity.X -= 0.05f;
            }
            else {
                player.velocity.X += 0.05f;
            }
            Main.NewText(player.velocity.X);
        }
    }
}