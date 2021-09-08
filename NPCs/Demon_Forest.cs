using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;

namespace TouhouFantasyMod.NPCs
{
    public class Demon_Forest : ModNPC
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
			if (TileID.Sets.Conversion.Grass[spawnInfo.spawnTileType] && Main.dayTime)
            {
                if (!spawnInfo.player.ZoneCorrupt)
                {
					if(!spawnInfo.player.ZoneJungle)
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
            Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCKilled, -1, -1, Mod.GetSoundSlot(SoundType.NPCKilled, "Sounds/NPCKilled/JiPo_1"));
		}

		//检查死亡（必须用于掉落物）
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Point.P_Point>(), 1));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Point.P_Point>(), 1));
			if (Main.rand.Next(3) < 1)//几分之几几率
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Point.P_Point>(), 1));
			}
		}

		//AI!
		public override void AI()
		{
            bool faceTarget = true;
			NPC.TargetClosest(faceTarget);//faceTarget 是真还是假取决于 npc.direction 是否应该更新以面对其目标

			Player player = Main.player[NPC.target];//获取 Boss 所针对的实际玩家对象 在此之后，使用 npc.target 获取目标

			Vector2 moveTo = player.Center + new Vector2(0f , -200f);//moveTo——要移动的位置 勉强理解成坐标

			float speed = 1.3f; 

			Vector2 move = moveTo - NPC.Center; //this is how much your boss wants to move

			float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y); //fun with the Pythagorean Theorem

			move *= speed / magnitude; //this adjusts your boss's speed so that its speed is always constant

			NPC.velocity = move;
		}
	}
}
