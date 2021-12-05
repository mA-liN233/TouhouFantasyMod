using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.Bestiary;
using TouhouFantasyMod.Projectiles.Rice;

namespace TouhouFantasyMod.NPCs
{
	public class Demon_Flower : ModNPC
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
			NPC.knockBackResist = 1f;//击退抗性，值越低击退抗性越高
			NPC.value = 1;//掉多少铜币，其实也可以在击杀后掉落那里写
			//npc.alpha = 254;//贴图透明度
			NPC.buffImmune[BuffID.DryadsWardDebuff] = true;//免疫buff
		}

		//生成方式
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (TileID.Sets.Conversion.Grass[spawnInfo.spawnTileType] && Main.dayTime)
			{
				if (!spawnInfo.player.ZoneCorrupt)
				{
					if (!spawnInfo.player.ZoneJungle)
					{
						return 0.3f;
					}
				}
			}
			return 0f;
		}

		//检查死亡（除掉落物以外的其他用途）
		public override void OnKill()
		{
			Terraria.Audio.SoundEngine.PlaySound(SoundLoader.GetLegacySoundSlot(Mod, "Sounds/NPCKilled/JiPo_1"));
		}

		//检查死亡（必须用于掉落物）
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Point.P_Point>(), 1));//第一个数字代表的是几分之几的概率
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Point.P_Point>(), 1));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Point.P_Point>(), 3));//三分之一的概率掉落第三个P点
		}

		//AI部分
		private enum ActionState
		{
			Leisure,
			Attack,
			Chase
		}
		public ref float AI_State => ref NPC.ai[0];
		public ref float AI_Timer => ref NPC.ai[1];
		public ref float AI_FlutterTime => ref NPC.ai[2];
		public override void AI()
		{
			//bool faceTarget = true;
			//NPC.TargetClosest(faceTarget);//faceTarget 是真还是假取决于 npc.direction 是否应该更新以面对其目标

			switch (AI_State)
			{
				case (float)ActionState.Leisure:
					//FallAsleep();
					break;
				case (float)ActionState.Attack:
					//Notice();
					break;
				case (float)ActionState.Chase:
					//Jump();
					break;
				/*case (float)ActionState.Fall:
					if (NPC.velocity.Y == 0)
					{
						NPC.velocity.X = 0;
						AI_State = (float)ActionState.Asleep;
						AI_Timer = 0;
					}

					break;*/
			}
		}
		private void Leisure()
        {
            if (NPC.life < 120)
            {
				AI_State = (float)ActionState.Attack;
			}
        }
		private void Attack()
        {
			NPC.TargetClosest(true);
			//弹幕呈花型散开，所以单颗弹幕的伤害不高
			int Type = ModContent.ProjectileType<Rice_Green>();
			Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.position, -Vector2.UnitY, Type, 2, 0.1f);
			//Projectile.NewProjectile(NPC.Center + new Vector2(96, 0).RotatedBy(r + ((time - 240) / 60 * 72) / 180 * MathHelper.Pi), new Vector2(32, 0).RotatedBy(r + ((time - 240) / 60 * 72)), ModNPC.ProjectileType("Rice.Rice_Green"), 2, 1, Main.myPlayer);
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] 
			{
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("一类开花之妖精，头脑简单，喜欢恶作剧和热闹的地方。接近未开花的草药她们会很高兴的让其盛开。")
			});
		}
	}
}
