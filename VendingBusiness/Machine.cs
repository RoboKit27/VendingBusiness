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

        private bool Session;
        private decimal SessionBalance;
        private double BarrelVolume = 12500;

        public Machine(int index)
        {
            this.Index = index;
        }

        private void MakeCoffee(double water, double coffee, double milk, bool shugar)
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
            }
        }
        private void BuyCoffee(decimal price)
        {
            if (this.SessionBalance >= price)
            {
                this.SessionBalance -= price;
            }
        }
        private decimal ReturnOddMoney()
        {
            this.Session = false;
            decimal oddMoney = this.SessionBalance;
            this.SessionBalance = 0;
            return oddMoney;
        }

        public void GetMoney(decimal sum)
        {
            if (sum > 0)
            {
                this.Balance += sum;
                this.SessionBalance += sum;
            }
            if (!this.Session)
            {
                this.Session = true;
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
        }

    }
}
