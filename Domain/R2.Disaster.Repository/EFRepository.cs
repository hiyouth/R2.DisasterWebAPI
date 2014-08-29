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
        /// ����
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saved">��ʾ�Ƿ���Ĳ���ִ�в��룬���false��ʾֻ������ӵ�ʵ�弯���У�����
        /// ����SaveChange����</param>
        /// <returns>����ʵ�������</returns>
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
        /// ���£����δ�����ٵ�ʵ�壬����Attached����������ʵ�弰ʵ����صĵ������ԣ���ȱ�����
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
        /// �ݹ麯������entity���䵼�������Լ��������Եĵ������ԣ��ݹ飩ȫ��Attach��������
        /// </summary>
        /// <param name="entity"></param>
        private void AttachedAllBaseEntity(BaseEntity entity)
        {
            //����ǰ��entity���и���
            this._context.DbSet(entity.GetType()).Attach(entity);
            this._context.Context.Entry(entity).State = EntityState.Modified;

            //����entity�����ԣ�������������Attach
            foreach (var propertyInfo in entity.GetType().GetProperties())
            {
                var v = propertyInfo.GetValue(entity, null);
                if (v is BaseEntity)
                {
                    //�Ǽ�������
                    this.AttachedAllBaseEntity(v as BaseEntity);
                    this._context.DbSet(v.GetType()).Attach(v);
                    this._context.Context.Entry(v).State = EntityState.Modified;
                }
                if (v is ICollection)
                {
                    //��������
                    ICollection vs = v as ICollection;
                    foreach (var item in vs)
                    {
                        //�����������������ÿһ��Ԫ��
                        this.AttachedAllBaseEntity(item as BaseEntity);
                        Type type = item.GetType();
                        this._context.DbSet(type).Attach(item);
                        this._context.Context.Entry(item).State = EntityState.Modified;
                    }
                }
            }
        }

        /// <summary>
        /// ���£�����Ѿ������ٵ�ʵ�壨����ͨ����ѯ�ķ����õ���ʵ�壬���޸ģ��ڸ��£�������
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
        /// ���£����ڻ�û�б����٣����磬new ������ʵ��������
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
                //TODO: ��֤��̫���ظ����룬������ȡ����Attribute���ԣ�
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