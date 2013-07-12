using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class Sys_IpAddress11Dto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string IP1 { get; set; }

        [DataMember]
        public string IP2 { get; set; }

        [DataMember]
        public string Province { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string Address { get; set; }

    }
}