namespace VendingBusiness
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ControlSystem controller = new ControlSystem();
            controller.Add(new CoffeeMachine(1));
        }
    }
}
