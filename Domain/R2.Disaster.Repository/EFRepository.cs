using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using R2.Disaster.Data;
using System.Collections.Generic;
using R2.Disaster.CoreEntities;
using System.Reflection;
using System.Collections;

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

        #region Update
        /// <summary>
        /// 更新，针对未被跟踪的实体，采用Attached方法来更新实体及实体相关的导航属性（深度遍历）
        /// </summary>
        /// <param name="entity"></param>
        public virtual void UpdateRelationAttached(BaseEntity entity)
        {
            //this._context.DbSet(typeof(T)).Attach(entity);
            //entity.GetType().
           //indingFlags.
          this.AttachedAllBaseEntity(entity);
          this._context.SaveChanges();
        }

        /// <summary>
        /// 递归函数，将entity及其导航属性以及导航属性的导航属性（递归）全部Attach跟踪起来
        /// </summary>
        /// <param name="entity"></param>
        private void AttachedAllBaseEntity(BaseEntity entity)
        {
            foreach (var propertyInfo in entity.GetType().GetProperties())
            {
                var v = propertyInfo.GetValue(entity, null);
                if (v is BaseEntity)
                {
                    //非集合类型
                    this.AttachedAllBaseEntity(v as BaseEntity);
                    this._context.DbSet(v.GetType()).Attach(v);
                    this._context.Context.Entry(v).State = EntityState.Modified;
                }
                if (v is ICollection)
                {
                    //集合类型
                    ICollection vs = v as ICollection;
                    foreach (var item in vs)
                    {
                        //遍历集合类型下面的每一个元素
                        this.AttachedAllBaseEntity(item as BaseEntity);
                        Type type = item.GetType();
                        this._context.DbSet(type).Attach(item);
                        this._context.Context.Entry(item).State = EntityState.Modified;
                    }
                }
            }
        }

        /// <summary>
        /// 更新，针对已经被跟踪的实体（如是通过查询的方法得到的实体，再修改，在更新）做更新
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
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

        /// <summary>
        /// 更新，对于还没有被跟踪，比如，new 出来的实体做更新
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateAttached(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this._context.DbSet(typeof(T)).Attach(entity);
                this._context.Context.Entry(entity).State = EntityState.Modified;
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
        #endregion

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