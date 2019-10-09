using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Smod.Commands {
    public class AnywhereButHere : ModCommand {
        public override CommandType Type => CommandType.World;
        public override string Command => "ABH";
        public override string Usage => "abh";
        public override string Description => "Gets you out of a tricky situation!";
        public override void Action(CommandCaller caller, string input, string[] args) {
            Player player = Main.LocalPlayer;
            player.position.X = Main.rand.Next(-200,Main.maxTilesX-200*16);
            player.position.Y = Main.rand.Next((int)Main.worldSurface*16-100,(int)Main.worldSurface*16);
        }
        /*
        private unsafe Vector2 TestTeleport(ref bool canSpawn, int teleportStartX, int teleportRangeX, int teleportStartY, int teleportRangeY) {
			int num = 0;
			int num2 = 0;
			int num3 = 0;
            Player player = Main.LocalPlayer;
			int width = player.width;
			Vector2 vector = new Vector2((float)num2, (float)num3) * 16f + new Vector2(-(float)width / 2f + 8f, -(float)player.height);
			while (!canSpawn && num < 1000)
			{
				num++;
				num2 = teleportStartX + Main.rand.Next(teleportRangeX);
				num3 = teleportStartY + Main.rand.Next(teleportRangeY);
				vector = new Vector2((float)num2, (float)num3) * 16f + new Vector2(-(float)width / 2f + 8f, -(float)player.height);
				if (!Collision.SolidCollision(vector, width, player.height))
				{
					if (Main.tile[num2, num3] == null)
					{
						Main.tile[num2, num3] = new Tile();
					}
					if ((Main.tile[num2, num3].wall != 87 || (double)num3 <= Main.worldSurface || NPC.downedPlantBoss) && (!Main.wallDungeon[(int)Main.tile[num2, num3].wall] || (double)num3 <= Main.worldSurface || NPC.downedBoss3))
					{
						int i = 0;
						while (i < 100)
						{
							if (Main.tile[num2, num3 + i] == null)
							{
								Main.tile[num2, num3 + i] = new Tile();
							}
							Tile tile = Main.tile[num2, num3 + i];
							vector = new Vector2((float)num2, (float)(num3 + i)) * 16f + new Vector2(-(float)width / 2f + 8f, -(float)player.height);
							Vector4* arg_1D1_0 = Collision.SlopeCollision(vector, player.velocity, width, player.height, player.gravDir, false);
							bool flag = !Collision.SolidCollision(vector, width, player.height);
							if (arg_1D1_0.Z == player.velocity.X)
							{
								Vector2 arg_1E9_0 = player.velocity;
							}
							if (flag)
							{
								i++;
							}
							else
							{
								if (tile.active() && !tile.inActive() && Main.tileSolid[(int)tile.type])
								{
									break;
								}
								i++;
							}
						}
						if (!Collision.LavaCollision(vector, width, player.height) && Collision.HurtTiles(vector, player.velocity, width, player.height, false).Y <= 0f)
						{
							Collision.SlopeCollision(vector, player.velocity, width, player.height, player.gravDir, false);
							if (Collision.SolidCollision(vector, width, player.height) && i < 99)
							{
								Vector2 vector2 = Vector2.UnitX * 16f;
								if (!(Collision.TileCollision(vector - vector2, vector2, player.width, player.height, false, false, (int)player.gravDir) != vector2))
								{
									vector2 = -Vector2.UnitX * 16f;
									if (!(Collision.TileCollision(vector - vector2, vector2, player.width, player.height, false, false, (int)player.gravDir) != vector2))
									{
										vector2 = Vector2.UnitY * 16f;
										if (!(Collision.TileCollision(vector - vector2, vector2, player.width, player.height, false, false, (int)player.gravDir) != vector2))
										{
											vector2 = -Vector2.UnitY * 16f;
											if (!(Collision.TileCollision(vector - vector2, vector2, player.width, player.height, false, false, (int)player.gravDir) != vector2))
											{
												canSpawn = true;
												num3 += i;
												break;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return vector;
		}
    }
}

public void TeleportationPotion()
		{
			bool flag = false;
			int teleportStartX = 100;
			int teleportRangeX = Main.maxTilesX - 200;
			int teleportStartY = 100;
			int teleportRangeY = Main.maxTilesY - 200;
			Vector2 vector = player.TestTeleport(ref flag, teleportStartX, teleportRangeX, teleportStartY, teleportRangeY);
			if (flag)
			{
				Vector2 vector2 = vector;
				player.Teleport(vector2, 2, 0);
				player.velocity = Vector2.Zero;
				if (Main.netMode == 2)
				{
					RemoteClient.CheckSection(player.whoAmI, player.position, 1);
					NetMessage.SendData(65, -1, -1, null, 0, (float)player.whoAmI, vector2.X, vector2.Y, 3, 0, 0);
				}
			}
		} 
        Para aplicar mas avanzado, ir a la def de la tp potion en player.cs ID = 2351
*/ 
    }
}