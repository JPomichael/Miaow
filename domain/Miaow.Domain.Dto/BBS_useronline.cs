using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_useronlineDto
    {
        [DataMember]
        public int userid { get; set; }

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public int userlev { get; set; }

        [DataMember]
        public DateTime logintime { get; set; }

        [DataMember]
        public string loginip { get; set; }

        [DataMember]
        public DateTime activetime { get; set; }

        [DataMember]
        public string placename { get; set; }

        [DataMember]
        public int placeid { get; set; }

    }
}