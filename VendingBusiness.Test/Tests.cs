namespace VendingBusiness.Test
{
    public class Tests
    {
        [TestCase(100, "Cola", "Null", 16)]
        [TestCase(100, "Pepsi", "Null", 14)]
        [TestCase(100, "Sprite", "Null", 31)]
        public void TestSodaPurchase(decimal money, string sodaType, string expectedError, decimal expectedOddMoney)
        {
            SodaMachine test = new(0);
            test.Repair();
            test.GetMoney(money);
            switch (sodaType)
            {
                case "Cola":
                    Assert.AreEqual(test.BuyCola(), expectedOddMoney);
                    break;
                case "Pepsi":
                    Assert.AreEqual(test.BuyPepsi(), expectedOddMoney);
                    break;
                case "Sprite":
                    Assert.AreEqual(test.BuySprite(), expectedOddMoney);
                    break;
            }
            Assert.AreEqual(test.Error, expectedError);
        }
        [TestCase(100, "Americano", "Null", 78)]
        [TestCase(100, "Cappuccino", "Null", 64)]
        [TestCase(100, "Latte", "Null", 59)]
        public void TestCoffeePurchase(decimal money, string coffeeType, string expectedError, decimal expectedOddMoney)
        {
            CoffeeMachine test = new(0);
            test.Repair();
            test.GetMoney(money);
            switch (coffeeType)
            {
                case "Americano":
                    Assert.AreEqual(test.BuyAmericano(true), expectedOddMoney);
                    break;
                case "Cappuccino":
                    Assert.AreEqual(test.BuyCappuccino(true), expectedOddMoney);
                    break;
                case "Latte":
                    Assert.AreEqual(test.BuyLatte(true), expectedOddMoney);
                    break;
            }
            Assert.AreEqual(test.Error, expectedError);
        }
    }
}