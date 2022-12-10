﻿using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool TrackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T,bool>> expression,bool TrackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);



    }
}