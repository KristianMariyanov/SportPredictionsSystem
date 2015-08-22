﻿namespace SportPredictionsSystem.Data.Contracts
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IDeletableEntityRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> AllWithDeleted();

        void HardDelete(T entity);

        void HardDelete(params object[] id);
    }
}
