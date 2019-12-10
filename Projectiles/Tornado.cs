using Terraria;
using Terraria.ModLoader;

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
        public void npc_no_damage(int time, NPC npc) { //Not working
            int damage = npc.damage;
            for (int i = 0; i < time; i++) {
                npc.damage = 0;
            }
            npc.damage = damage;
        }
        public override void AI() {
            bool in_screen = false;
            foreach (NPC npc in Main.npc) {
                in_screen = npc.position.X <= Main.screenWidth + Main.screenPosition.X
                            && npc.position.Y <= Main.screenHeight  + Main.screenPosition.Y
                            && npc.position.X >= Main.screenPosition.X
                            && npc.position.Y >= Main.screenPosition.Y;
                if(in_screen && npc.CanBeChasedBy(projectile) && !npc.boss) {
                    npc.velocity += npc.DirectionTo(projectile.Center)*1.5f; //TODO: Hacerlo como un tornado, cosa que los npcs giren en torno al proyectil
                    npc_no_damage(projectile.timeLeft,npc);
                }
            }
        }
    }
}