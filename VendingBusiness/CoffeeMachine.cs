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
            this._errorList.Add("NotWater");
            this._errorList.Add("NotCoffee");
            this._errorList.Add("NotMilk");
            this._errorList.Add("NotShugar");
        }

        public decimal BuyAmericano(bool shugar)
        {
            this.BuyDrink(this._coffeeRecipes[0].Price);
            this.MakeCoffee(this._coffeeRecipes[0], shugar);
            return this.ReturnOddMoney();
        }
        public decimal BuyCappuccino(bool shugar)
        {
            this.BuyDrink(this._coffeeRecipes[1].Price);
            this.MakeCoffee(this._coffeeRecipes[1], shugar);
            return this.ReturnOddMoney();
        }
        public decimal BuyLatte(bool shugar)
        {
            this.BuyDrink(this._coffeeRecipes[2].Price);
            this.MakeCoffee(this._coffeeRecipes[2], shugar);
            return this.ReturnOddMoney();
        }
        public void Repair()
        {
            this.Balance = 10000;
            this.Water = CoffeeMachineOptions.BarrelVolume;
            this.Coffee = CoffeeMachineOptions.BarrelVolume;
            this.Milk = CoffeeMachineOptions.BarrelVolume;
            this.Shugar = CoffeeMachineOptions.BarrelVolume;
            if (this._errorList.IndexOf(this.Error) > 1 && this._errorList.IndexOf(this.Error) < 6)
            {
                this.Error = "Null";
            }
        }

        private void MakeCoffee(CoffeeRecipe recipe, bool shugar)
        {
            if (this.Error == "Null")
            {
                if (this.Water >= recipe.Water && this.Coffee >= recipe.Coffee && this.Milk >= recipe.Milk)
                {
                    this.Water -= recipe.Water;
                    this.Coffee -= recipe.Coffee;
                    this.Milk -= recipe.Milk;
                    if (shugar)
                    {
                        if (this.Shugar >= 10)
                        {
                            this.Shugar -= 10;
                        }
                        else
                        {
                            this.Error = "NotShugar";
                        }
                    }
                }
                else
                {
                    if (this.Water < recipe.Water)
                    {
                        this.Error = "NotWater";
                    }
                    else if (this.Coffee < recipe.Coffee)
                    {
                        this.Error = "NotCoffee";
                    }
                    else
                    {
                        this.Error = "NotMilk";
                    }
                }
            }
        }

    }

}
