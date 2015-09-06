namespace SportPredictionsSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;

    using SportPredictionsSystem.Data.Contracts;
    using SportPredictionsSystem.Data.Models;

    public class SportPredictionsSystemDbContext : IdentityDbContext<User>, ISportPredictionsSystemDbContext
    {
        public SportPredictionsSystemDbContext()
            : this("DefaultConnection")
        {
        }

        public SportPredictionsSystemDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString, false)
        {
        }

        public virtual IDbSet<FootballPrediction> FootballPredictions { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public static SportPredictionsSystemDbContext Create()
        {
            return new SportPredictionsSystemDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();

#if DEBUG
            //// Use this to see DB validation errors
            return this.SaveChangesWithTracingDbExceptions();
#else
            return base.SaveChanges();
#endif
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(e => e.Entity is IAuditInfo && (e.State == EntityState.Added || e.State == EntityState.Modified)))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private int SaveChangesWithTracingDbExceptions()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Exception currentException = ex;
                while (currentException != null)
                {
                    Trace.TraceInformation(currentException.Message);
                    currentException = currentException.InnerException;
                }

                throw;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {1}{0} Error: {2}", Environment.NewLine, validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw;
            }
        }
    }
}
