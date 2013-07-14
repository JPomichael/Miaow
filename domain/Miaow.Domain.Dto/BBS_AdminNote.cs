using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_AdminNoteDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string admin_username { get; set; }

        [DataMember]
        public DateTime admin_time { get; set; }

        [DataMember]
        public string admin_work { get; set; }

        [DataMember]
        public int admin_boardid { get; set; }

        [DataMember]
        public string admin_bbs_title { get; set; }

        [DataMember]
        public string admin_bbscontent { get; set; }

        [DataMember]
        public string admin_bbsauthor { get; set; }

        [DataMember]
        public int admin_addCoin { get; set; }

        [DataMember]
        public int admin_reduceCoin { get; set; }

        [DataMember]
        public int admin_noPostTime { get; set; }

        [DataMember]
        public string admin_info { get; set; }

    }
}