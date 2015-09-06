namespace SportPredictionsSystem.Data
{
    using System;
    using System.Collections.Generic;

    using SportPredictionsSystem.Data.Contracts;
    using SportPredictionsSystem.Data.Models;
    using SportPredictionsSystem.Data.Repositories.Base;

    public class SportPredictionsSystemData : ISportPredictionsSystemData
    {
        private readonly ISportPredictionsSystemDbContext dbContext;
        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public SportPredictionsSystemData(ISportPredictionsSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IDeletableEntityRepository<FootballPrediction> FootballPredictions => this.GetDeletableEntityRepository<FootballPrediction>();

        public IDeletableEntityRepository<User> Users => this.GetDeletableEntityRepository<User>();

        public IRepository<Country> Countries => this.GetRepository<Country>();

        public ISportPredictionsSystemDbContext Context => this.dbContext;

        public void Dispose()
        {
            this.dbContext?.Dispose();
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity, new()
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.dbContext));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
