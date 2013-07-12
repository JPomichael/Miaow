using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_CoinAddSetupDto
    {
        [DataMember]
        public int CoinAdd_Type { get; set; }

        [DataMember]
        public int CoinAdd_GoodNum { get; set; }

        [DataMember]
        public int CoinAdd_GoodAdd { get; set; }

        [DataMember]
        public int CoinAdd_BadNum { get; set; }

        [DataMember]
        public int CoinAdd_BadAdd { get; set; }

        [DataMember]
        public int CreditAdd { get; set; }

        [DataMember]
        public int CreditReduct { get; set; }

    }
}