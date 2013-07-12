using System;
using System.Runtime.Serialization;

namespace iPow.Service.SSO.Entity
{
    [DataContract]
    public class SecurityToken : Token
    {
        /// <summary>
        /// Gets or sets the login id.
        /// </summary>
        /// <value>The login id.</value>
        [DataMember]
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value>The create time.</value>
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        [DataMember]
        public bool IsValid { get; set; }
    }
}
