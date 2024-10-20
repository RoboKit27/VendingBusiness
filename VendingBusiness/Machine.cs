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
        private decimal SessionOddMoney;
        private decimal SessionBalance;
        private double BarrelVolume = 12500;

        public Machine(int index)
        {
            this.Index = index;
        }
    }
}
