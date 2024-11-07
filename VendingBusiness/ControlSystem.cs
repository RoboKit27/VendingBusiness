namespace VendingBusiness
{
    public class ControlSystem
    {

        private List<BaseMachine> _machines = new List<BaseMachine>();

        public ControlSystem()
        {

        }

        public BaseMachine Machine(int index)
        {
            foreach (BaseMachine item in this._machines)
            {
                if (item.Index == index)
                {
                    return item;
                }
            }
            return null;
        }
        public int Add(BaseMachine machine)
        {
            foreach (BaseMachine item in this._machines)
            {
                if (item.Index == machine.Index)
                {
                    return 1;
                }
            }
            this._machines.Add(new CoffeeMachine(machine.Index));
            return 0;
        }
        public int Remove(int index)
        {
            foreach (BaseMachine item in this._machines)
            {
                if (item.Index == index)
                {
                    this._machines.Remove(item);
                }
            }
            return 1;
        }
        public decimal GetTotalEarnings()
        {
            decimal earnings = 0;
            foreach (BaseMachine item in this._machines)
            {
                earnings += item.Earnings;
            }
            return earnings;
        }
        public List<int> Repair()
        {
            List<int> repairedMachines = new List<int>();
            foreach (BaseMachine item in this._machines)
            {
                if (item.GetRepairNeed())
                {
                    item.Repair();
                    repairedMachines.Add(item.Index);
                }
            }
            return repairedMachines;
        }

    }
}
