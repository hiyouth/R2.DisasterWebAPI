using R2.Disaster.CoreEntities;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.Repository;
using R2.Disaster.Service.GeoDisaster;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service
{
    public class EntityServiceBase<T>  where T:BaseEntity
    {
        protected IRepository<T> _repository;

        public EntityServiceBase(IRepository<T> repository)
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

        public void UpdateAttached(T entity)
        {
            this._repository.UpdateAttached(entity);
        }
         
        public T Get(object id)
        {
            return this._repository.GetById(id);
        }

        public void Delete(T entity)
        {
            this._repository.Delete(entity);
        }

        public void Delete(object id)
        {
            this._repository.Delete(id);
        }

        public void New(T entity)
        {
                //if (entity.GetType().BaseType == typeof(BaseEntity))
                //{
                //    BaseEntity t = entity as BaseEntity;
                //    t.RecordTime = DateTime.Now;
                //}
            this.RecordTimeAllBaseEntity(entity);
            this._repository.Insert(entity);
        }


        //public void Update(IList<T> entities)
        //{
        //    this._repository.Update(entities);
        //}

        public void UpdateRelationAttached(BaseEntity entity)
        {
            this._repository.UpdateRelationAttached(entity);
        }

        public void Delete(IList<T> entities)
        {
            this._repository.Delete(entities);
        }

        public void Delete(IList<object> ids)
        {
            this._repository.Delete(ids);
        }

        public void New(IList<T> entities)
        {
            //foreach (var entity in entities)
            //{
            //    if (entity.GetType().BaseType == typeof(BaseEntity))
            //    {
            //        BaseEntity t = entity as BaseEntity;
            //        t.RecordTime = DateTime.Now;
            //    }
            //}
            foreach (var item in entities)
            {
                this.RecordTimeAllBaseEntity(item);
            }
            this._repository.Insert(entities);
        }

        private void RecordTimeAllBaseEntity(BaseEntity entity)
        {
            entity.RecordTime = DateTime.Now;
            foreach (var propertyInfo in entity.GetType().GetProperties())
            {
                var v = propertyInfo.GetValue(entity, null);
                if (v is BaseEntity)
                {
                    //非集合类型
                    BaseEntity subEntityBase = v as BaseEntity;
                    this.RecordTimeAllBaseEntity(subEntityBase);
                    //subEntityBase.RecordTime = DateTime.Now;
                }
                if (v is ICollection<BaseEntity>)
                {
                    //集合类型
                    ICollection<BaseEntity> vs = v as ICollection<BaseEntity>;
                    foreach (var item in vs)
                    {
                        //遍历集合类型下面的每一个元素
                        BaseEntity subEntityBase = v as BaseEntity;
                        this.RecordTimeAllBaseEntity(item as BaseEntity);
                        //Type type = item.GetType();
                        //subEntityBase.RecordTime = DateTime.Now;
                    }
                }
            }
        }

        public IQueryable<T> FindAll()
        {
            return this._repository.Table;
        }
    }
}
