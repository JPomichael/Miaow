using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_poll_voterDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int boardid { get; set; }

        [DataMember]
        public int bbsid { get; set; }

        [DataMember]
        public int potnid { get; set; }

        [DataMember]
        public int userid { get; set; }

        [DataMember]
        public string username { get; set; }

    }
}