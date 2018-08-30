namespace BankSystem.DAL.Interface.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using DTO;

    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetAll();

        T GetById(int key);

        T GetByPredicate(Expression<Func<T, bool>> f);

        void Create(T e);

        void Delete(T e);

        void Update(T e);
    }
}
