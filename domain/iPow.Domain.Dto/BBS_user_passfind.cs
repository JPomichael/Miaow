using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_user_passfindDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string pass_code { get; set; }

        [DataMember]
        public DateTime addtime { get; set; }

        [DataMember]
        public int isfind { get; set; }

    }
}