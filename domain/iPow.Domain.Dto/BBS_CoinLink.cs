using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_CoinLinkDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int boardid { get; set; }

        [DataMember]
        public int bbsid { get; set; }

        [DataMember]
        public int CoinLink_type { get; set; }

        [DataMember]
        public string CoinLink_name { get; set; }

        [DataMember]
        public string CoinLink_url { get; set; }

        [DataMember]
        public int CoinLink_num { get; set; }

        [DataMember]
        public decimal downcount { get; set; }

    }
}