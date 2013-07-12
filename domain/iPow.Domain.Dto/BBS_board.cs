using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_boardDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string board_name { get; set; }

        [DataMember]
        public int board_root { get; set; }

        [DataMember]
        public string board_explain { get; set; }

        [DataMember]
        public string board_explain_master { get; set; }

        [DataMember]
        public string board_img { get; set; }

        [DataMember]
        public int board_px { get; set; }

        [DataMember]
        public int board_topictype { get; set; }

        [DataMember]
        public int board_topic_count { get; set; }

        [DataMember]
        public int board_rebbs_count { get; set; }

        [DataMember]
        public int today_post_count { get; set; }

        [DataMember]
        public DateTime last_update_time { get; set; }

        [DataMember]
        public string last_update_username { get; set; }

        [DataMember]
        public int board_open { get; set; }

        [DataMember]
        public string board_usergroup { get; set; }

        [DataMember]
        public int board_list { get; set; }

        [DataMember]
        public int board_show_explain { get; set; }

        [DataMember]
        public int today_topic_count { get; set; }

    }
}