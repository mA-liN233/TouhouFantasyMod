using Terraria.ModLoader;
using System.IO;
using Terraria;
using Terraria.GameContent.UI;

namespace TouhouFantasyMod
{
	public class TouhouFantasyMod : Mod
	{
		public static ModKeybind BOOMKey;
		public static ModKeybind SeasonLiberatedKey;
		public override void Load()
		{
            BOOMKey = KeybindLoader.RegisterKeybind(this,"释放BOOM","X");
			SeasonLiberatedKey = KeybindLoader.RegisterKeybind(this,"季节解放","C");
		}
	}
}