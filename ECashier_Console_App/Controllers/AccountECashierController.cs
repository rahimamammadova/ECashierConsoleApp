using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ECashier_Console_App.Models;

namespace ECashier_Console_App.Controllers
{
    internal class AccountECashierController : Account
    {
        public int accountSearchId { get; set; }
        public int accountDetailSearchId { get; set; }
        public List<ECashier> ECashiers { get; set; }

        public AccountECashierController()
        {
            ECashiers = new List<ECashier>();
            Console.WriteLine("Create E-Cashier");
        }

        public void CreateECashier()
        {
            Console.Write("Enter your username: ");
            Username = Console.ReadLine();
            Console.Write("Enter your password: ");
            Password = Console.ReadLine();

            ID = new Random().Next(10000000, 99999999);

            ECashiers.Add(new Account() { ID = ID, Username = Username, Password = Password });

            Console.WriteLine("You have successfully created an E-Cashier!");
            Console.WriteLine($"Your ID: {ID}");
            Console.Write("Would you like to continue? Press y/x: ");
            Response = char.Parse(Console.ReadLine());
        }

        public void CreateAccount()
        {
            Console.Write("Enter the currency: ");
            Currency = Console.ReadLine();

            Console.Write("Enter the assignment of account (e.g salary, collection): ");
            Assignment = Console.ReadLine();

            Console.Write("Enter balance:");
            Balance = double.Parse(Console.ReadLine());

            Console.Write("Enter status of your account(active/disabled): ");
            ActivationStatus = Console.ReadLine();

            Accounts.Add(new Account() { AccountID = base.ID, Balance = Balance,
                Currency = Currency, Assignment = Assignment, ActivationStatus = ActivationStatus });

            Console.Write("Account has been created. Would you like to create another account? Press y/x: ");

            Response = char.Parse(Console.ReadLine());
        }

        public void ShowAccountInfo()
        {
            foreach (var accounts in Accounts.ToArray())
            {
                Console.WriteLine($"Account ID: {accounts.AccountID}");
                Console.WriteLine($"Balance: {accounts.Balance}");
                Console.WriteLine($"Currency: {accounts.Currency}");
                Console.WriteLine($"Assignment: {accounts.Assignment}");
                Console.WriteLine($"Activation status: {accounts.ActivationStatus}");
            }
            return;
        }
        public void ShowAccountInfo(int accountIDNumberForSearch)
        {
            foreach (var accounts in Accounts.Where(y => y.AccountID == accountIDNumberForSearch).ToList())
            {
                Console.WriteLine($"Account ID: {accounts.AccountID}");
                Console.WriteLine($"Balance: {accounts.Balance}");
                Console.WriteLine($"Currency: {accounts.Currency}");
                Console.WriteLine($"Assignment: {accounts.Assignment}");
                Console.WriteLine($"Activation status: {accounts.ActivationStatus}");
            }
            return;
        }

        public void AcountAuth(string _userName, string _password)
        {

            if (ECashiers.Any(p => p.Username == _userName) && ECashiers.Any(l => l.Password == _password))
            {
                ShowAccountInfo(accountDetailSearchId);
            }
            else
            {
                Console.WriteLine("Username or password is incorrect.");
                return;
            }
            return;
        }
    }
}
