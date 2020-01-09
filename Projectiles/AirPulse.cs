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
        Player player = Main.LocalPlayer;
        public override void AI() {
            player.velocity -= player.DirectionTo(projectile.Center);
        }
    }
}