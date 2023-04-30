using ECashier_Console_App.Models;
using ECashier_Console_App.Controllers;

string username = " ";
string password = " ";
int accountID = 0;
double ammount = 0;
string status = " ";
char mainMenuStatus = 'y';

AccountECashierController accountController = new AccountECashierController();
AccountOperationsController operations = new AccountOperationsController();
Account account = new Account();

do
{
    Console.WriteLine("1.Create an e-cashier");
    Console.WriteLine("2.Create an e-cashier account");
    Console.WriteLine("3.Show all accounts related to the e-cashier");
    Console.WriteLine("4.Show accounts according to account number");
    Console.WriteLine("5.Exit");
    Console.Write("Please choose operation number:");

    int operationNum = int.Parse(Console.ReadLine());
    switch (operationNum)
    {
        case 1:
            accountController.CreateECashier();
            if (accountController.Response == ('y') || accountController.Response == ('Y'))
            {
                while (accountController.Activation)
                {
                    accountController.CreateAccount();

                    if (accountController.Response == ('y') || accountController.Response == ('Y'))
                    {
                        accountController.CreateECashier();
                    }
                    else
                    {
                        Login();
                        accountController.Activation = false;
                    }
                }
            }
            else
            {
                Login();
            }
            break;
        case 2: accountController.CreateAccount(); break;
        case 3:
            accountController.ShowAccountInfo(); break;
        case 4:
            Console.Write("Please enter your Account ID: ");
            int ID;
            ID = int.Parse(Console.ReadLine());
            accountController.ShowAccountInfo(ID);
            Login(); break;
        case 5: mainMenuStatus = 'x'; break;
    }
} while (mainMenuStatus == 'y');

void Login()
{
    Console.Write("Would you like to sign in to your account?");
    account.Response = char.Parse(Console.ReadLine());

    if (account.Response == ('y') || account.Response == ('Y'))
    {
        SignInToAccount();
        accountController.AcountAuth(username, password);
        AccountOperation();
    }
}

void SignInToAccount()
{
    Console.Write("To login enter your username: ");
    username = Console.ReadLine();
    Console.Write("To login enter your password: ");
    password = Console.ReadLine();
}

void AccountOperation()
{
    Console.WriteLine("1.Deposit money into account");
    Console.WriteLine("2.Withdraw money from account");
    Console.WriteLine("3.Show account history");
    Console.WriteLine("4.Activate/Deactivate account");
    Console.WriteLine("5.Show main menu");
    Console.Write("Please enter operation number: ");

    int operationNum = int.Parse(Console.ReadLine());
    operations.OperationNumber = operationNum;
    switch (operationNum)
    {
        case 1:
            Console.Write("Enter ammount that you want to deposit to your account:");
            ammount = double.Parse(Console.ReadLine());
            accountController.Balance = operations.MoneyDeposit(accountController.Balance, ammount);
            Console.WriteLine($"Current balance: {accountController.Balance}");
            AccountOperation();
            break;
        case 2:
            Console.Write("Enter ammount that you want to withdraw:");
            ammount = double.Parse(Console.ReadLine());
            accountController.Balance = operations.WithDraw(accountController.Balance, ammount);
            Console.WriteLine($"Current balance: {accountController.Balance}");
            AccountOperation();
            break;
        case 3:
            Console.WriteLine("Show account history: ");
            foreach (var operations in operations.Operations)
            {
                Console.WriteLine(operations);
            }
            AccountOperation();
            break;
        case 4:
            Console.Write("For activation choose a, for deactivation choose d: ");
            status = Console.ReadLine();
            accountController.ActivationStatus = operations.ActivationDeactivation(status);
            Console.WriteLine($"Current status: {accountController.ActivationStatus}");
            AccountOperation();
            break;
        case 5:
            break;
    }
}