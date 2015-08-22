namespace SportPredictionsSystem.Data.Contracts
{
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        T GetById(params object[] id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(params object[] id);

        void Detach(T entity);
    }
}
