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

        private Error ErrorStatus = Error.Null;
        private decimal SessionBalance;
        private double BarrelVolume = 12500;

        public Machine(int index)
        {
            this.Index = index;
        }

        private void MakeCoffee(double water, double coffee, double milk, bool shugar)
        {
            if (this.ErrorStatus == Error.Null)
            {
                if (this.Water >= water && this.Coffee >= coffee && this.Milk >= milk)
                {
                    this.Water -= water;
                    this.Coffee -= coffee;
                    this.Milk -= milk;
                    if (shugar && this.Shugar >= 10)
                    {
                        this.Shugar -= 10;
                    }
                    else
                    {
                        this.CompileError(Error.NotShugar);
                    }
                }
                else
                {
                    if (this.Water < water)
                    {
                        this.CompileError(Error.NotWater);
                    }
                    else if (this.Coffee < coffee)
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
            if (this.SessionBalance >= price && this.ErrorStatus == Error.Null)
            {
                this.SessionBalance -= price;
            }
        }
        private decimal ReturnOddMoney()
        {
            if (this.ErrorStatus == Error.Null)
            {
                decimal oddMoney = this.SessionBalance;
                this.SessionBalance = 0;
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

        public void GetMoney(decimal sum)
        {
            if (sum > 0)
            {
                this.Balance += sum;
                this.SessionBalance += sum;
                if (this.ErrorStatus == Error.FewMoney)
                {
                    this.ErrorStatus = Error.Null;
                }
            }
        }
        public decimal BuyAmericano(bool shugar)
        {
            this.BuyCoffee((decimal)Americano.Price);
            this.MakeCoffee((double)Americano.Water, (double)Americano.Coffee, 0, shugar);
            return this.ReturnOddMoney();
        }
        public decimal BuyCappuccino(bool shugar)
        {
            this.BuyCoffee((decimal)Cappuccino.Price);
            this.MakeCoffee((double)Cappuccino.Water, (double)Cappuccino.Coffee, 0, shugar);
            return this.ReturnOddMoney();
        }
        public decimal BuyLatte(bool shugar)
        {
            this.BuyCoffee((decimal)Latte.Price);
            this.MakeCoffee((double)Latte.Water, (double)Latte.Coffee, 0, shugar);
            return this.ReturnOddMoney();
        }
        public void Repair()
        {
            this.Balance = 10000;
            this.Water = this.BarrelVolume;
            this.Coffee = this.BarrelVolume;
            this.Milk = this.BarrelVolume;
            this.Shugar = this.BarrelVolume;
            if (this.ErrorStatus == Error.NotWater && this.ErrorStatus == Error.NotCoffee && this.ErrorStatus == Error.NotMilk && this.ErrorStatus == Error.NotShugar)
            {
                this.ErrorStatus = Error.Null;
            }
        }

    }
}
