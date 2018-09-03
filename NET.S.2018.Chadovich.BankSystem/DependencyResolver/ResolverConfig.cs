using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.DAL.Interface.Interfaces;
using DAL.ORM;
using Ninject;
using ORM.Model;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<OrmUnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<BankModel>().InSingletonScope();
            }
        }
    }
}
