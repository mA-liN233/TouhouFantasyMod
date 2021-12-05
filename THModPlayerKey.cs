using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using TouhouFantasyMod.Buffs.Boom;
using TouhouFantasyMod.Items.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using Terraria.Utilities;

namespace TouhouFantasyMod
{
    public class THModPlayerKey : ModPlayer
    {
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
            //int itemid = ModContent.ItemType<Yubi>();
            if (TouhouFantasyMod.BOOMKey.JustPressed&&Player.inventory[Player.selectedItem].type == ModContent.ItemType<Yubi>())
            {
                Player.AddBuff(ModContent.BuffType<SpiritualSP_DreamSeal>(), 360);
            }
        }
	}
}
