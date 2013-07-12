using System.Runtime.Serialization;
using System;

namespace iPow.Service.SSO.Entity
{
    [DataContract]
    public class User
    {
        /// <summary>
        /// Gets or sets the login domain.
        /// </summary>
        /// <value>The login domain.</value>
        [DataMember]
        public string LoginDomain { get; set; }

        /// <summary>
        /// Gets or sets the login ip address.
        /// </summary>
        /// <value>The login ip address.</value>
        [DataMember]
        public string LoginIpAddress { get; set; }

        #region Dto

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string password { get; set; }

        [DataMember]
        public string lastloginip { get; set; }

        [DataMember]
        public DateTime lastlogintime { get; set; }

        [DataMember]
        public int logintimes { get; set; }

        [DataMember]
        public int roleid { get; set; }

        [DataMember]
        public int userid { get; set; }

        [DataMember]
        public string truename { get; set; }

        [DataMember]
        public int style { get; set; }

        [DataMember]
        public string sex { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string UserType { get; set; }

        [DataMember]
        public string UserGuid { get; set; }

        [DataMember]
        public string DepartmentID { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public bool Activity { get; set; }

        [DataMember]
        public int EmployeeID { get; set; }

        #endregion
    }
}
