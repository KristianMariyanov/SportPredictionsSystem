namespace SportPredictionsSystem.Data
{
    using System;

    using SportPredictionsSystem.Data.Contracts;
    using SportPredictionsSystem.Data.Models;

    public interface ISportPredictionsSystemData : IDisposable
    {
        IRepository<Country> Countries { get; }

        IDeletableEntityRepository<FootballPrediction> FootballPredictions { get; }

        IDeletableEntityRepository<User> Users { get; }

        int SaveChanges();
    }
}
