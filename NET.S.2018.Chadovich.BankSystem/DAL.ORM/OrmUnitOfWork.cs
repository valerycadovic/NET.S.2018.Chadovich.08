namespace DAL.ORM
{
    using System;
    using System.Data.Entity;
    using BankSystem.DAL.Interface.Interfaces;

    public class OrmUnitOfWork: IUnitOfWork
    {
        private readonly Lazy<IAccountRepository> _lazyAccountRepository;

        private readonly Lazy<IHolderRepository> _lazyHolderRepository;

        public OrmUnitOfWork(DbContext dbContext, IAccountRepository accounts, IHolderRepository holders)
        {
            Context = dbContext ?? throw new ArgumentNullException();
            this._lazyAccountRepository = new Lazy<IAccountRepository>(() => accounts);
            this._lazyHolderRepository = new Lazy<IHolderRepository>(() => holders);
        }

        public DbContext Context { get; }

        public IAccountRepository Accounts => _lazyAccountRepository.Value;

        public IHolderRepository Holders => _lazyHolderRepository.Value;

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
