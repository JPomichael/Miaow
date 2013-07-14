using System;
using System.Runtime.Serialization;

namespace Miaow.Service.SSO.Entity
{
    [DataContract]
    public class OnlineUser : User
    {
        /// <summary>
        /// Gets or sets the login time.
        /// </summary>
        /// <value>The login time.</value>
        [DataMember]
        public DateTime LoginTime { get; set; }
    }
}
