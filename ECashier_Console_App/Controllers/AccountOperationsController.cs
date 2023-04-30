namespace ECashier_Console_App.Controllers
{
    internal class AccountOperationsController
    {
        public int OperationNumber { get; set; }
        public List<double> Operations { get; set; }

        public AccountOperationsController()
        {
            Operations = new List<double>();
        }

        public double MoneyDeposit(double balance, double ammount)
        {
            balance += ammount;
            Operations.Add(+ammount);
            return balance;
        }

        public double WithDraw(double balance, double ammount)
        {
            if (balance == 0 || ammount > balance) 
            {
                Console.WriteLine("You don't have enough money in your balance"); 
            }
            else
            {
                balance -= ammount;
            }
            Operations.Add(-ammount);
            return balance;
        }

        public string ActivationDeactivation(string ActivationStatus)
        {
            if (ActivationStatus.Equals("active"))
            {
                ActivationStatus = "Active";
            }
            else
            {
                ActivationStatus = "Deactivated";
            }
            return ActivationStatus;
        }
    }
}
