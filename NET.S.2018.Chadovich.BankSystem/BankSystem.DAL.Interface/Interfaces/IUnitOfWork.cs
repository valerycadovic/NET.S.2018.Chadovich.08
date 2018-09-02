namespace BankSystem.DAL.Interface.Interfaces
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
