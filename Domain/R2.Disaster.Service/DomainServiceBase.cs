using R2.Disaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service
{
    public class DomainServiceBase<T>
    {
        protected IRepository<T> _repository;

        public DomainServiceBase(IRepository<T> repository)
        {
            this._repository = repository;
        }
        /// <summary>
        /// 根据条件，返回符合条件的集合
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IQueryable<T> ExecuteConditions(Expression<Func<T, bool>> condition)
        {
            return this._repository.Table.Where(condition.Compile()).AsQueryable<T>();
        }

        public void Update(T entity)
        {
            this._repository.Update(entity);
        }

        public T Get(object id)
        {
            return this._repository.GetById(id);
        }

        public void Delete(T entity)
        {
            this._repository.Delete(entity);
        }

        public void Delete(int id)
        {
            this._repository.Delete(id);
        }

        public void New(T entity)
        {
            this._repository.Insert(entity);
        }
    }
}
