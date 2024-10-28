using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingBusiness
{
    public class Machine
    {

        public int Index { get; private protected set; }
        public decimal Balance { get; private protected set; }
        public Error ErrorStatus { get; private protected set; }

        private protected decimal _sessionBalance;

        public Machine(int index)
        {
            this.Index = index;
            this.ErrorStatus = Error.Null;
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
        protected decimal ReturnOddMoney()
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
        protected void CompileError(Error errorCode)
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
