using System.Collections.Generic;
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

        void Insert(IList<T> entities);
        void Update(T entity);

        void Update(IList<T> entities);
        void Delete(T entity);

        void Delete(IList<T> entities);

        void Delete(object id);

        void Delete(IList<object> id);

        IQueryable<T> Table { get; }
    }
}
