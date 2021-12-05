using Terraria;
using Terraria.ModLoader;

/*namespace TouhouFantasyMod.Buffs.Boom
{
	public class SpiritualSP_DreamSeal : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("灵符「梦想封印」"); // Buff display name
			Description.SetDefault("霊符「夢想封印」"); // Buff description
			Main.debuff[Type] = false;  // Is it a debuff?
			Main.pvpBuff[Type] = false; // Players can give other players buffs, which are listed as pvpBuff
			Main.buffNoSave[Type] = true; // It means the buff won't save when you exit the world
			LongerExpertDebuff = true; // If this buff is a debuff, setting this to true will make this buff last twice as long on players in expert mode
		}

		// Allows you to make this buff give certain effects to the given player
		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<SpiritualSP_DreamSeal>().lifeRegenDebuff = true;
		}
	}
}*/

namespace TouhouFantasyMod.Buffs.Boom
{
	// This class serves as an example of a debuff that causes constant loss of life
	// See ExampleLifeRegenDebuffPlayer.UpdateBadLifeRegen at the end of the file for more information
	public class SpiritualSP_DreamSeal : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("灵符「梦想封印」"); // Buff display name
			Description.SetDefault("霊符「夢想封印」"); // Buff description
			Main.debuff[Type] = true;  // Is it a debuff?
			Main.pvpBuff[Type] = false; // Players can give other players buffs, which are listed as pvpBuff
			Main.buffNoSave[Type] = true; // It means the buff won't save when you exit the world
			LongerExpertDebuff = false; // If this buff is a debuff, setting this to true will make this buff last twice as long on players in expert mode
		}

		// Allows you to make this buff give certain effects to the given player
		public override void Update(Player player, ref int buffIndex)
		{
			//player.GetModPlayer<SpiritualSP_DreamSealPlayer>().lifeRegenDebuff = true;
			player.immune = true;
		}
	}

	/*public class SpiritualSP_DreamSealPlayer : ModPlayer
	{
		// Flag checking when life regen debuff should be activated
		public bool lifeRegenDebuff;

		// Allows you to give the player a negative life regeneration based on its state (for example, the "On Fire!" debuff makes the player take damage-over-time)
		// This is typically done by setting player.lifeRegen to 0 if it is positive, setting player.lifeRegenTime to 0, and subtracting a number from player.lifeRegen
		// The player will take damage at a rate of half the number you subtract per second
		public override void UpdateBadLifeRegen()
		{
			
		}
	}*/
}
