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