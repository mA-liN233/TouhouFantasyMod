using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;

namespace TouhouFantasyMod.NPCs
{
	public class TestNPC : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("测试NPC");
		}
		public override void SetDefaults()
		{
			NPC.width = 50;//碰撞箱宽
			NPC.height = 50;//碰撞箱高
			NPC.scale = 2f;//游戏里显示的贴图大小，数字代表倍数（应该）
			NPC.aiStyle = -1;//使用的AI，如果自定义AI必须改成-1
			NPC.damage = 0;//碰撞伤害
			NPC.defense = 0;//防御
			NPC.lifeMax = 10000000;//生命值 专家会自动翻倍！
			NPC.HitSound = SoundID.NPCHit1;//受伤音效
			NPC.noGravity = true;//是否无视重力（飞行）
			NPC.noTileCollide = true;//是否穿墙
			NPC.knockBackResist = 0f;//击退抗性，值越低击退抗性越高
		}

		//检查死亡（除掉落物以外的其他用途）
		public override void OnKill()
		{
			Terraria.Audio.SoundEngine.PlaySound(SoundLoader.GetLegacySoundSlot(Mod, "Sounds/NPCKilled/JiPo_1"));
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("测试武器用的NPC，我也不知道为什么要给这玩意写图鉴")
			});
		}
	}
}
