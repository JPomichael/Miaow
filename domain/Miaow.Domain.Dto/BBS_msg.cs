using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_msgDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string touser { get; set; }

        [DataMember]
        public string fromuser { get; set; }

        [DataMember]
        public string msg_title { get; set; }

        [DataMember]
        public string msg_content { get; set; }

        [DataMember]
        public DateTime addtime { get; set; }

        [DataMember]
        public string addip { get; set; }

        [DataMember]
        public int isread { get; set; }

    }
}