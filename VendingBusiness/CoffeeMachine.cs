using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingBusiness
{
    public class CoffeeMachine : Machine
    {

        public double Water { get; private set; }
        public double Coffee { get; private set; }
        public double Milk { get; private set; }
        public double Shugar { get; private set; }

        private List<CoffeeRecipe> _coffeeRecipes;

        public CoffeeMachine(int index) : base(index)
        {
            _coffeeRecipes = CoffeeMachineOptions.GetCoffeeRecipes();
        }

        public decimal BuyAmericano(bool shugar)
        {
            this.BuyCoffee(this._coffeeRecipes[0].Price);
            this.MakeCoffee(this._coffeeRecipes[0], shugar);
            return this.ReturnOddMoney();
        }
        public decimal BuyCappuccino(bool shugar)
        {
            this.BuyCoffee(this._coffeeRecipes[1].Price);
            this.MakeCoffee(this._coffeeRecipes[1], shugar);
            return this.ReturnOddMoney();
        }
        public decimal BuyLatte(bool shugar)
        {
            this.BuyCoffee(this._coffeeRecipes[2].Price);
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
            if (this.ErrorStatus == Error.NotWater && this.ErrorStatus == Error.NotCoffee && this.ErrorStatus == Error.NotMilk && this.ErrorStatus == Error.NotShugar)
            {
                this.ErrorStatus = Error.Null;
            }
        }

        private void MakeCoffee(CoffeeRecipe recipe, bool shugar)
        {
            if (this.ErrorStatus == Error.Null)
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
                            this.CompileError(Error.NotShugar);
                        }
                    }
                }
                else
                {
                    if (this.Water < recipe.Water)
                    {
                        this.CompileError(Error.NotWater);
                    }
                    else if (this.Coffee < recipe.Coffee)
                    {
                        this.CompileError(Error.NotCoffee);
                    }
                    else
                    {
                        this.CompileError(Error.NotMilk);
                    }
                }
            }
        }
        private void BuyCoffee(decimal price)
        {
            if (this._sessionBalance >= price && this.ErrorStatus == Error.Null)
            {
                Console.WriteLine($"{price} {this._sessionBalance}");
                this._sessionBalance -= price;
            }
            else
            {
                this.CompileError(Error.FewMoney);
            }
        }

    }
}
