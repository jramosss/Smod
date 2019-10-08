using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace Smod
{
	class Smod : Mod
	{
		public Smod()
		{
		}

		public override void AddRecipeGroups()
    		{
    			RecipeGroup LunarPickaxes = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Lunar Pickaxes", new int[]
    			{
    				ItemID.SolarFlarePickaxe,
					ItemID.VortexPickaxe,
					ItemID.NebulaPickaxe,
					ItemID.StardustPickaxe
    			});

				RecipeGroup LunarAxes = new RecipeGroup ( () => Language.GetTextValue("LegacyMisc.37") + " Lunar Axes", new int []{
					ItemID.SolarFlarePickaxe,
					ItemID.VortexAxe,
					ItemID.NebulaAxe,
					ItemID.StardustAxe
				});
    			RecipeGroup.RegisterGroup("Smod:LunarPickaxes", LunarPickaxes);
				RecipeGroup.RegisterGroup("Smod:LunarAxes", LunarAxes); 
			
		}
	}
}
