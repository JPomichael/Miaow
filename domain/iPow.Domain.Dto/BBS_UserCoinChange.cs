using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_UserCoinChangeDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string changetype { get; set; }

        [DataMember]
        public string fromUsername { get; set; }

        [DataMember]
        public string toUsername { get; set; }

        [DataMember]
        public int coin_num { get; set; }

        [DataMember]
        public string explain { get; set; }

        [DataMember]
        public DateTime addtime { get; set; }

        [DataMember]
        public string addip { get; set; }

        [DataMember]
        public int userid { get; set; }

    }
}