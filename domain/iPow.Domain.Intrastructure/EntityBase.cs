using System;

namespace iPow.Domain.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class EntityBase
    {
        #region Members

        private int? requestedHashCode;

        private Guid sysId;

        #endregion

        #region Properties

        /// <summary>
        /// Get or set the persisten object identifier
        /// </summary>
        public virtual Guid SysId
        {
            get
            {
                return sysId;
            }
            set
            {
                sysId = value;
                OnIdChanged();
            }
        }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Called when [id changed].
        /// </summary>
        protected virtual void OnIdChanged()
        {

        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Check if this entity is transient, ie, without identity at this moment
        /// 瞬态
        /// </summary>
        /// <returns>True if entity is transient, else false</returns>
        public bool IsTransient()
        {
            return this.SysId == Guid.Empty;
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is EntityBase))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }
            EntityBase item = (EntityBase)obj;
            if (item.IsTransient() || this.IsTransient())
            {
                return false;
            }
            else
            {
                return item.SysId == this.SysId;
            }
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!requestedHashCode.HasValue)
                {
                    requestedHashCode = this.SysId.GetHashCode() ^ 31;
                }
                return requestedHashCode.Value;
            }
            else
            {
                return base.GetHashCode();
            }
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(EntityBase left, EntityBase right)
        {
            if (Object.Equals(left, null))
            {
                return (Object.Equals(right, null)) ? true : false;
            }
            else
            {
                return left.Equals(right);
            }
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(EntityBase left, EntityBase right)
        {
            return !(left == right);
        }

        #endregion
    }
}
