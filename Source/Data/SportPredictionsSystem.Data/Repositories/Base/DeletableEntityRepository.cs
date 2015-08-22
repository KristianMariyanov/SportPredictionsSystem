namespace SportPredictionsSystem.Data.Repositories.Base
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using SportPredictionsSystem.Data.Contracts;

    public class DeletableEntityRepository<T> : GenericRepository<T>, IDeletableEntityRepository<T>
        where T : class, IDeletableEntity, new()
    {
        public DeletableEntityRepository(DbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> All()
        {
            return base.All().Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return base.All();
        }

        public override void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            this.Update(entity);
        }

        public override void Delete(params object[] id)
        {
            var entity = this.GetById(id);

            this.Delete(entity);
        }

        public virtual void HardDelete(T entity)
        {
            base.Delete(entity);
        }

        public virtual void HardDelete(params object[] id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                base.Delete(entity);
            }
        }
    }
}
