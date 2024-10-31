﻿namespace VendingBusiness
{
    public abstract class BaseMachine
    {

        public int Index { get; protected set; }
        public decimal Balance { get; protected set; }
        public String Error { get; protected set; }

        protected List<String> _errorList = new List<String>()
        {
            "Null",
            "FewMoney"
        };
        protected decimal _sessionBalance;
        protected decimal _salesPrice;

        public BaseMachine(int index)
        {
            this.Index = index;
            this.Error = "Null";
        }

        public void GetMoney(decimal sum)
        {
            if (sum > 0)
            {
                this.Balance += sum;
                this._sessionBalance += sum;
                if (this.Error == "FewMoney")
                {
                    this.Error = "Null";
                }
            }
        }
        protected decimal ReturnOddMoney()
        {
            if (this.Error == "Null")
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
        protected void BuyDrink(decimal price)
        {
            if (this._sessionBalance >= price)
            {
                this._sessionBalance -= price;
                this._salesPrice += price;
                if (this.Error == "FewMoney")
                {
                    this.Error = "Null";
                }
            }
            else
            {
                this.Error = "FewMoney";
            }
        }
        public override bool Equals(object? obj)
        {
            return obj is BaseMachine machine &&
                   _salesPrice == machine._salesPrice;
        }
    }
}