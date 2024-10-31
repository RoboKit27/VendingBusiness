using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingBusiness
{
    public class CoffeeMachine : BaseMachine
    {

        public double Water { get; private set; }
        public double Coffee { get; private set; }
        public double Milk { get; private set; }
        public double Shugar { get; private set; }

        private List<CoffeeRecipe> _coffeeRecipes;

        public CoffeeMachine(int index) : base(index)
        {
            _coffeeRecipes = CoffeeMachineOptions.GetCoffeeRecipes();
            _errorList.Add("NotWater");
            _errorList.Add("NotCoffee");
            _errorList.Add("NotMilk");
            _errorList.Add("NotShugar");
        }

        public decimal BuyAmericano(bool shugar)
        {
            BuyDrink(_coffeeRecipes[0].Price);
            MakeCoffee(_coffeeRecipes[0], shugar);
            return ReturnOddMoney();
        }
        public decimal BuyCappuccino(bool shugar)
        {
            BuyDrink(_coffeeRecipes[1].Price);
            MakeCoffee(_coffeeRecipes[1], shugar);
            return ReturnOddMoney();
        }
        public decimal BuyLatte(bool shugar)
        {
            BuyDrink(_coffeeRecipes[2].Price);
            MakeCoffee(_coffeeRecipes[2], shugar);
            return ReturnOddMoney();
        }
        public void Repair()
        {
            Balance = 10000;
            Water = CoffeeMachineOptions.BarrelVolume;
            Coffee = CoffeeMachineOptions.BarrelVolume;
            Milk = CoffeeMachineOptions.BarrelVolume;
            Shugar = CoffeeMachineOptions.BarrelVolume;
            if (_errorList.IndexOf(Error) > 1 && _errorList.IndexOf(Error) < 6)
            {
                Error = "Null";
            }
        }

        private void MakeCoffee(CoffeeRecipe recipe, bool shugar)
        {
            if (Error == "Null")
            {
                if (Water >= recipe.Water && Coffee >= recipe.Coffee && Milk >= recipe.Milk)
                {
                    Water -= recipe.Water;
                    Coffee -= recipe.Coffee;
                    Milk -= recipe.Milk;
                    if (shugar)
                    {
                        if (Shugar >= 10)
                        {
                            Shugar -= 10;
                        }
                        else
                        {
                            Error = "NotShugar";
                        }
                    }
                }
                else
                {
                    if (Water < recipe.Water)
                    {
                        Error = "NotWater";
                    }
                    else if (Coffee < recipe.Coffee)
                    {
                        Error = "NotCoffee";
                    }
                    else
                    {
                        Error = "NotMilk";
                    }
                }
            }
        }

    }

}
