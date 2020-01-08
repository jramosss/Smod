using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace Smod.Projectiles {
    internal class AirPulse : ModProjectile {
        public override void SetDefaults() {
            projectile.width = 15;
            projectile.height = 15;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 50;
            drawOffsetX = 5;
            drawOriginOffsetY = 5;
            projectile.damage = 0;
        }
        private static Player player = Main.LocalPlayer;
        private Vector2 x = player.position;
        public override void AI() {
            //var direction = player.DirectionTo(projectile.Center);
            player.velocity.X -= (float)-(Math.Pow(x.Y,2));
        }
        public override void Kill(int timeLeft) {
        }
    }
}