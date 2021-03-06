using System;

namespace R2.Disaster.CoreEntities
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public  abstract class BaseEntity

    {
        /// <summary>
        /// 
        /// </summary>
        protected BaseEntity()
        {
            Id = Guid.NewGuid().ToString("N");
        }
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 给予用户一个自定义的主键，以便于用户可以使用一个自定义的键位来串接各实体间的关系
        /// </summary>
        public string CustomizeId { get; set; }

        /// <summary>
        /// 数据录入时间
        /// </summary>
        public DateTime? RecordTime { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as BaseEntity);
        }

        private static bool IsTransient(BaseEntity obj)
        {
            return obj != null && Equals(obj.Id, default(int));
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }

        public bool Equals(BaseEntity other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (!IsTransient(this) &&
                !IsTransient(other) &&
                Equals(Id, other.Id))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                        otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (Equals(Id, default(int)))
                return base.GetHashCode();
            return Id.GetHashCode();
        }

        public static bool operator ==(BaseEntity x, BaseEntity y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(BaseEntity x, BaseEntity y)
        {
            return !(x == y);
        }
    }
}
