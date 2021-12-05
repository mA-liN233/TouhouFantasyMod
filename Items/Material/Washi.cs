using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TouhouFantasyMod.Items.Material
{
    public class Washi : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("和纸");
        }
        public override void SetDefaults()
        {
            Item.maxStack = 99;
            Item.value = Item.sellPrice(0, 0, 6, 0);
            Item.rare = 0;
            Item.autoReuse = false;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.BambooBlock, 3)
            .AddIngredient(ItemID.Wood, 1)
            .AddTile(TileID.Loom)
            .AddCondition(Recipe.Condition.NearWater)
            .Register();
        }
    }
}
