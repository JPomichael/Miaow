using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_user_groupDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string group_name { get; set; }

        [DataMember]
        public int isdefault { get; set; }

    }
}