using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingBusiness
{
    public class Machine
    {
        public int Index { get; private set; }
        public decimal Balance { get; private set; }
        public double Water { get; private set; }
        public double Coffee { get; private set; }
        public double Milk { get; private set; }
        public double Shugar { get; private set; }
        public Error ErrorStatus { get; private set; }

        private decimal _sessionBalance;
        private List<CoffeeRecipe> _coffeeRecipes;

        public Machine(int index)
        {
            this.Index = index;
            this.ErrorStatus = Error.Null;
            _coffeeRecipes = MachineOptions.GetCoffeeRecipes();
        }
        
        public void GetMoney(decimal sum)
        {
            if (sum > 0)
            {
                this.Balance += sum;
                this._sessionBalance += sum;
                if (this.ErrorStatus == Error.FewMoney)
                {
                    this.ErrorStatus = Error.Null;
                }
            }
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
            this.Water = MachineOptions.BarrelVolume;
            this.Coffee = MachineOptions.BarrelVolume;
            this.Milk = MachineOptions.BarrelVolume;
            this.Shugar = MachineOptions.BarrelVolume;
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
                this._sessionBalance -= price;
            }
            else
            {
                this.CompileError(Error.FewMoney);
            }
        }
        private decimal ReturnOddMoney()
        {
            if (this.ErrorStatus == Error.Null)
            {
                decimal oddMoney = this._sessionBalance;
                this._sessionBalance = 0;
                return oddMoney;
            }
            else
            {
                return 0;
            }
        }
        private void CompileError(Error errorCode)
        {
            this.ErrorStatus = errorCode;
            if (errorCode == Error.FewMoney)
            {
                Console.WriteLine("Внесённой суммы денег не хватает! Пополните баланс!");
            }
            else if (errorCode == Error.NotWater)
            {
                Console.WriteLine("Закончилась вода!");
            }
            else if (errorCode == Error.NotCoffee)
            {
                Console.WriteLine("Закончилось кофе!");
            }
            else if (errorCode == Error.NotMilk)
            {
                Console.WriteLine("Закончилось молоко!");
            }
            else if (errorCode == Error.NotShugar)
            {
                Console.WriteLine("Закончился сахар!");
            }
        }

    }
}
