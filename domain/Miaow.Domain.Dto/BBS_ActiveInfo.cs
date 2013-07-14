using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_ActiveInfoDto
    {
        [DataMember]
        public int bbs_usercount { get; set; }

        [DataMember]
        public string bbs_newuser { get; set; }

    }
}