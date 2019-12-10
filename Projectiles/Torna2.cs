using Terraria;
using Terraria.ModLoader;

namespace Smod.Projectiles {
    public class Torna2 : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Torna2 Balls");
        }
        public override void SetDefaults() {
            projectile.width = 80;
			projectile.height = 120;
			projectile.alpha = 0;
			projectile.timeLeft = 850;
			projectile.penetrate = -1;
			projectile.hostile = false;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
            projectile.friendly = true;
            projectile.position = Main.MouseWorld;
        }
        public override void AI() {
            bool in_screen = false;
            Tornado tornado = new Tornado();
            foreach (NPC npc in Main.npc) {
                in_screen = npc.position.X <= Main.screenWidth + Main.screenPosition.X
                            && npc.position.Y <= Main.screenHeight  + Main.screenPosition.Y
                            && npc.position.X >= Main.screenPosition.X
                            && npc.position.Y >= Main.screenPosition.Y;
                if(in_screen && npc.CanBeChasedBy(projectile) && !npc.boss) {
                    npc.velocity += npc.DirectionTo(projectile.Center)*2.5f; //TODO: Hacerlo como un tornado, cosa que los npcs giren en torno al proyectil
                    tornado.npc_no_damage(projectile.timeLeft,npc);
                }
            }
        }
    }
}