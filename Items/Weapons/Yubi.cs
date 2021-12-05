using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TouhouFantasyMod.DamageClasses;
using TouhouFantasyMod.Buffs.Boom;

namespace TouhouFantasyMod.Items.Weapons
{
    public class Yubi : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("御币");
            Tooltip.SetDefault("袪除邪恶\n拿在手中按下X键释放BOOM");
            Item.staff[base.Item.type] = true;

        }
        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;
            Item.scale = 0.95f;

            Item.damage = 13;
            Item.DamageType = ModContent.GetInstance<SPDamageClass>();
            Item.mana = 6;//法力消耗
            Item.knockBack = 5.0f;
            Item.crit = 6;//暴击率，默认有4% 所以真实暴击应该是设置的数值+4

            Item.useStyle = 5;
            
            Item.useTime = 7;//攻击速度 单位帧 游戏一秒60帧 
            Item.useAnimation = 5;//攻击动画持续时间，一般设置成和攻击速度一样

            Item.value = Item.sellPrice(0, 1, 20, 0);
            Item.rare = 2;//稀有度

            Item.maxStack = 1;

            Item.noMelee = true;

            Item.autoReuse = true;//按住鼠标自动攻击

            Item.UseSound = SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Item/FaDan");

            Item.shoot = ModContent.ProjectileType<Projectiles.Yubi.Ofuda>();
            Item.shootSpeed = 35f;//每帧多少像素
        }

        //调整贴图在手中的位置
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0f, 0f);
        }

        /*public override bool Shoot(Player player,Item item)
        {
            return false;
        }*/

        /*public virtual void HoldItem(Player Player)
        {
            if (TouhouFantasyMod.BOOMKey.JustPressed)
            {
                Player.AddBuff(ModContent.BuffType<SpiritualSP_DreamSeal>(), 600);
            }
        }*/

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(Terraria.ID.ItemID.Wood, 3)
            .AddIngredient(null, "Washi", 4)
            .AddTile(Terraria.ID.TileID.Loom)
            .Register();
        }

    }
}