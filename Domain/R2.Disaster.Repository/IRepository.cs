using System.Linq;

namespace R2.Disaster.Repository
{
    /// <summary>
    /// Repository
    /// </summary>
    public partial interface IRepository<T>
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object id);
        IQueryable<T> Table { get; }
    }
}
