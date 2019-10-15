/* 
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Smod.Projectiles {
    internal class BombardaProj : ModProjectile {
        public override void SetDefaults() {
            // while the sprite is actually bigger than 15x15, we use 15x15 since it lets the projectile clip into tiles as it bounces. It looks better.
            projectile.width = 15;
            projectile.height = 15;
            projectile.friendly = true;
            projectile.penetrate = -1;

            // 5 second fuse.
            projectile.timeLeft = 40;

            // These 2 help the projectile hitbox be centered on the projectile sprite.
            drawOffsetX = 5;
            drawOriginOffsetY = 5;
		}
    }
}
*/