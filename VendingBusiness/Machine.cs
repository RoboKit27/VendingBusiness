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

        public void GetMoney(decimal sum)
        {
            if (sum > 0)
            {
                this.SessionBalance += sum;
            }
            if (!this.Session)
            {
                this.Session = true;
            }
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
