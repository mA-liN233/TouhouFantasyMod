using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TouhouFantasyMod.Items.Point
{
    public class P_Point : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("P点");
            Tooltip.SetDefault("提高发出弹幕的伤害");//写个和灾厄肾上腺素一样的UI栏，最高4.00|直接整个仪器在聊天栏显示数字表示也行（
        }
        public override void SetDefaults()
        {
            Item.maxStack = 99;
            Item.useStyle = 4;
            Item.value = Item.sellPrice(0, 0, 0, 0);
            Item.rare = 0;
            Item.autoReuse = false;
        }
    }
}
