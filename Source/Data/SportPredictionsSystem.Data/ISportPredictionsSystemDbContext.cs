namespace SportPredictionsSystem.Data
{
    using System;
    using System.Data.Entity;

    using SportPredictionsSystem.Data.Models;

    public interface ISportPredictionsSystemDbContext : IDisposable
    {
        IDbSet<User> Users { get; set; }

        IDbSet<FootballPrediction> FootballPredictions { get; set; }

        int SaveChanges();
    }
}
