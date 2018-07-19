using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.Accounts.Factories;
using BankSystem.Core;
using BankSystem.Service.AccountsService;
using ListAccountsRepository;

namespace BankSystem.CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repository = ListRepository.Instance;
            IService service = new BankService(repository, new GuidAccountNumberGenerator());

            AccountHolder holder1 = new AccountHolder("Valery Chadovich", "+375 (25) 957-7240", "valerachad03@gmail.com");
            AccountHolder holder2 = new AccountHolder("Natalla Chadovich", "+375 (29) 705-1346", "pancialejeva@gmail.com");
            AccountHolder holder3 = new AccountHolder("Kaciaryna Lapotka", "+375 (44) 723-6954", "katy.lap99@gmail.com");
            AccountHolder holder4 = new AccountHolder("Natalla Chadovich", "+375 (29) 705-1346", "pancialejeva@gmail.com");

            service.OpenAccount(holder1, new BaseAccountFactory());
            service.OpenAccount(holder1, new GoldAccountFactory());
            service.OpenAccount(holder2, new PlatinumAccountFactory());
            service.OpenAccount(holder3, new SilverAccountFactory());
            service.OpenAccount(holder4, new PlatinumAccountFactory());

            foreach (var acc in repository.GetAll())
            {
                for (int i = 1; i < 10; i++)
                {
                    acc.Deposit(i * 1000);
                    acc.Withdraw(i * 500);
                }
            }

            foreach (var acc in repository.GetAll())
            {
                Console.WriteLine(acc.Id);
                Console.WriteLine();
                Console.WriteLine(acc.Holder.Name);
                Console.WriteLine(acc.Holder.Email);
                Console.WriteLine(acc.Holder.Phone);
                Console.WriteLine();
                Console.WriteLine(acc.Balance);
                Console.WriteLine(acc.BonusPoints);
                Console.WriteLine("---------------------");
            }

            Console.ReadKey();
        }
    }
}
