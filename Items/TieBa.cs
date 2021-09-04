using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TouhouFantasyMod.Items
{
    public class TieBa : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("百度贴吧");
            Tooltip.SetDefault("新人求问：为什么蘑菇人不来啊？[图片]");
        }
        public override void SetDefaults()
        {
            Item.maxStack = 1;
            Item.useStyle = 4;
            Item.value = Item.sellPrice(0, 0, 0, 0);
            Item.rare = 2;
            Item.autoReuse = false;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
        .   AddIngredient(ItemID.WaterBucket, 1)
        .   Register();
        }
    }
}
