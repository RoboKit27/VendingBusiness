namespace VendingBusiness
{
    public static class CoffeeMachineOptions
    {
        public const double BarrelVolume = 12500;

        public static List<CoffeeRecipe> GetCoffeeRecipes()
        {
            return new List<CoffeeRecipe>()
            {
                new CoffeeRecipe()
                {
                    Name="Американо",
                    Price=22,
                    Water=150,
                    Coffee=30,
                    Milk=0
                },
                new CoffeeRecipe()
                {
                    Name="Капучино",
                    Price=36,
                    Water=30,
                    Coffee=30,
                    Milk=100
                },
                new CoffeeRecipe()
                {
                    Name="Латте",
                    Price=41,
                    Water=30,
                    Coffee=30,
                    Milk=140
                }
            };
        }

    }

}
