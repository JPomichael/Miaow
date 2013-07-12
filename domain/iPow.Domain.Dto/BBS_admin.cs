using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_adminDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string admin_name { get; set; }

        [DataMember]
        public string admin_realname { get; set; }

        [DataMember]
        public string admin_pass { get; set; }

        [DataMember]
        public DateTime login_time { get; set; }

        [DataMember]
        public string login_ip { get; set; }

        [DataMember]
        public string username { get; set; }

    }
}