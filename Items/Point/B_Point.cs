using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TouhouFantasyMod.Items.Point
{
    public class B_Point : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("B点");
            Tooltip.SetDefault("使用武器时按下[快捷键，暂时还没写]释放Bomb");//这玩意是消耗品|可以加个决死机制，这个决死应当是永夜抄的决死机制
        }
        public override void SetDefaults()
        {
            Item.maxStack = 99;
            Item.useAmmo = 4;
            Item.value = Item.sellPrice(0, 0, 0, 0);
            Item.rare = 2;
            Item.autoReuse = false;
        }
    }

}
