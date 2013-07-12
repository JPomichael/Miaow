using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_ActivityappliesDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int applyid { get; set; }

        [DataMember]
        public int fid { get; set; }

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string message { get; set; }

        [DataMember]
        public int verified { get; set; }

        [DataMember]
        public string dateline { get; set; }

        [DataMember]
        public int payment { get; set; }

        [DataMember]
        public string contact { get; set; }

        [DataMember]
        public int userid { get; set; }

    }
}