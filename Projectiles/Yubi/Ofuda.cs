using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using TouhouFantasyMod.DamageClasses;

namespace TouhouFantasyMod.Projectiles.Yubi
{
    public class Ofuda : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("御札");
        }
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 15;
            Projectile.scale = 1.5f;//放大
            Projectile.hostile = false;//敌对
            Projectile.friendly = true;//对敌方造成伤害
            Projectile.DamageType = ModContent.GetInstance<SPDamageClass>();//伤害类型
            Projectile.ignoreWater = false;//水里不减速
            //Projectile.penetrate = 3;//穿透多少个敌人
            Projectile.timeLeft = 600;//弹幕持续时间（帧）
            Projectile.tileCollide = true;//不穿墙
            Projectile.light = 0.3f;//发光，强度
            //Projectile.alpha = 255;//贴图透明度
            Projectile.aiStyle = -1;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            Projectile.alpha = 255;
            if (Projectile.timeLeft < 599)
            {
                Projectile.alpha = 0;
            }

        }
        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return true;
        }
    }
}
