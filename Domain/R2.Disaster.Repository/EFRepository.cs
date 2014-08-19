using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using R2.Disaster.Data;
using System.Collections.Generic;
using R2.Disaster.CoreEntities;
using System.Reflection;

namespace R2.Disaster.Repository
{
    /// <summary>
    /// Entity Framework repository
    /// </summary>
    public partial class EFRepository<T> : IRepository<T> where T :BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public EFRepository(IDbContext context)
        {
            this._context = context;
        }

        public virtual T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saved">表示是否真的插入执行插入，如果false表示只是先添加到实体集合中，而不
        /// 调用SaveChange方法</param>
        /// <returns>新增实体的主键</returns>
        public virtual void Insert(T entity, bool saved=true)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Add(entity);

                if (saved)
                {
                    this._context.SaveChanges();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public virtual void UpdateAttached(T entity,bool save=true)
        {
            //this._context.DbSet(typeof(T)).Attach(entity);
            //entity.GetType().
           //indingFlags.
          foreach (var propertyInfo in typeof(T).GetProperties())             
          {                     //对象对应属性值变量(可以用列表添加)                    //是你的student 类型实例                
              var v = propertyInfo.GetValue(entity, null);
              if (v is BaseEntity)
              {
                  this._context.DbSet(v.GetType()).Attach(v);
              }
          }
        }

        public virtual void Update(T entity,bool saved=true)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                if (saved)
                {
                    this._context.SaveChanges();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public virtual void Delete(T entity ,bool saved =true)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Remove(entity);

                if (saved)
                {
                    this._context.SaveChanges();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }


        public void Delete(object id,bool saved=true)
        {
            T entity=this.GetById(id);
            this.Delete(entity,saved);
        }


        public void Insert(IList<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Insert(entity,false);
            }
            try
            {
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public void Update(IList<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Update(entity,false);
            }
            try
            {
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public void Delete(IList<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Delete(entity,false);
            }
            try
            {
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public void Delete(IList<object> ids)
        {
            foreach (var id  in ids)
            {
                this.Delete(id, false);
            }
            try
            {
                 this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                //TODO: 验证有太多重复代码，考虑提取，用Attribute特性？
               var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }
    }
}