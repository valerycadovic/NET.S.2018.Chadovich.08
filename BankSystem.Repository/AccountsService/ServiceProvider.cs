using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.Core;
using ListAccountsRepository;

namespace BankSystem.Service.AccountsService
{
    public static class ServiceProvider
    {
        public static IService GetService() => new BankService(ListRepository.Instance, new GuidAccountNumberGenerator());
    }
}
