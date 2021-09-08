using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
//using TouhouFantasyMod.Utils;

namespace TouhouFantasyMod.Projectiles.Rice
{
    public class Rice_Red : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("米弹");
        }
        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 14;
            Projectile.scale = 1.6f;//放大
            Projectile.hostile = true;//敌对
            Projectile.DamageType = DamageClass.Magic;//伤害类型
            Projectile.ignoreWater = true;//水里不减速
            Projectile.timeLeft = 1200;//弹幕持续时间（帧）
            Projectile.tileCollide = true;//不穿墙
            Projectile.light = 0.5f;//发光，强度
        }
    }
}
