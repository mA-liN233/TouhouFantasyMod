using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace TouhouFantasyMod.NPCs
{
	public class Demon_Jungle : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("妖精");
			Main.npcFrameCount[NPC.type] = 4;//把贴图竖着分成4份
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.spriteDirection = NPC.direction;
			NPC.frameCounter += 1.0; //让动画运行（浮点数单位）
			NPC.frameCounter %= 24.0; //24个刻度（ticks）后动画重新开始。一秒有60个刻度（浮点数单位）
			int frame = (int)(NPC.frameCounter / 6.0); //帧定格时间，单位刻（浮点数单位）
			NPC.frame.Y = frame * frameHeight; //Actually sets the frame
		}

		public override void SetDefaults()
		{
			NPC.width = 28;//碰撞箱宽
			NPC.height = 27;//碰撞箱高
			NPC.scale = 1.5f;//游戏里显示的贴图大小，数字代表倍数（应该）
			NPC.aiStyle = -1;//使用的AI，如果自定义AI必须改成-1
			//aiType = NPCID.Hornet;//沿用原版生物的AI
			NPC.damage = 3;//碰撞伤害
			NPC.defense = 2;//防御
			NPC.lifeMax = 40;//生命值 专家会自动翻倍！
			NPC.HitSound = SoundID.NPCHit1;//受伤音效
			NPC.noGravity = true;//是否无视重力（飞行）
			NPC.noTileCollide = false;//是否穿墙
			NPC.knockBackResist = 0.1f;//击退抗性，值越低击退抗性越高
			NPC.value = 1;//掉多少铜币，其实也可以在击杀后掉落那里写
			//npc.alpha = 254;//贴图透明度
		}

		//生成方式
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.player.ZoneJungle && Main.dayTime)
			{
				return 0.3f;
			}
			return 0f;
		}



		//检查死亡（除掉落物以外的其他用途）
		public override void OnKill()
		{
			Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCKilled, -1, -1, Mod.GetSoundSlot(SoundType.NPCKilled, "Sounds/NPCKilled/JiPo_1"));
		}

		//检查死亡（必须用于掉落物）
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Point.P_Point>(), 1));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Point.P_Point>(), 1));
			if (Main.rand.Next(2) < 1)//几分之几几率
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Point.P_Point>(), 1));
			}
		}

		//AI!
		public override void AI()
		{

			NPC.TargetClosest(true);//寻找最近的玩家
			Player player = Main.player[NPC.target];//target 目标
			Vector2 moveTo = player.Center /*+ new Vector2(-150f)*/;//player.Center玩家中心 moveTo代表以玩家为中心的坐标系原点
			//moveTo = player.Center + new Vector2(200f);
			//npc.position = moveTo;//npc位置 = moveTo（坐标系原点） 此行实现npc瞬移到玩家的功能
			float speed = 1.5f;
			Vector2 move = moveTo - NPC.Center; //行动 = 以玩家为原点 - 以npc为原点
			double magnitude;//magnitude大小/幅度/规模
			magnitude = Math.Sqrt(move.X * move.X + move.Y * move.Y);//X轴上的行动*X轴上的行动 + Y轴上的行动*Y轴上的行动
			//勾股定理的乐趣是吧
			move *= speed / (float)magnitude;//行动=速度/move.X * move.X + move.Y * move.Y
			NPC.velocity = move;//行动 = 行动目标
			(NPC.Center - Main.player[NPC.target].Center).Length();

		}
	}
}
