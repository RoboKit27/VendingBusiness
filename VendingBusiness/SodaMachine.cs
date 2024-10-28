namespace VendingBusiness
{
    public class SodaMachine : Machine
    {

        public int ColaAmount { get; private set; }
        public int PepsiAmount { get; private set; }
        public int SpriteAmount { get; private set; }

        public SodaMachine(int index) : base(index)
        {
            this._errorList.Add("NotCola");
            this._errorList.Add("NotPepsi");
            this._errorList.Add("NotSprite");
        }

        public decimal BuyCola()
        {
            this.BuyDrink((decimal)Cola.Price);
            if (this.ColaAmount != 0)
            {
                this.ColaAmount -= 1;
            }
            else
            {
                this.Error = "NotCola";
            }
            return this.ReturnOddMoney();
        }
        public decimal BuyPepsi()
        {
            this.BuyDrink((decimal)Pepsi.Price);
            if (this.PepsiAmount != 0)
            {
                this.PepsiAmount -= 1;
            }
            else
            {
                this.Error = "NotPepsi";
            }
            return this.ReturnOddMoney();
        }
        public decimal BuySprite()
        {
            this.BuyDrink((decimal)Sprite.Price);
            if (this.SpriteAmount != 0)
            {
                this.SpriteAmount -= 1;
            }
            else
            {
                this.Error = "NotSprite";
            }
            return this.ReturnOddMoney();
        }
        public void Repair()
        {
            this.Balance = 10000;
            this.ColaAmount = SodaMachineOptions.MaxJarCount;
            this.PepsiAmount = SodaMachineOptions.MaxJarCount;
            this.SpriteAmount = SodaMachineOptions.MaxJarCount;
            if (this._errorList.IndexOf(this.Error) > 1 && this._errorList.IndexOf(this.Error) < 5)
            {
                this.Error = "Null";
            }
        }

    }
}
