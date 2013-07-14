using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_topicDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int boardid { get; set; }

        [DataMember]
        public int userid { get; set; }

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public int TopicType { get; set; }

        [DataMember]
        public string TopicHeart { get; set; }

        [DataMember]
        public string title { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public int rootid { get; set; }

        [DataMember]
        public DateTime AddTime { get; set; }

        [DataMember]
        public string AddIP { get; set; }

        [DataMember]
        public int Hits { get; set; }

        [DataMember]
        public int RepostCount { get; set; }

        [DataMember]
        public int RepostUserid { get; set; }

        [DataMember]
        public string RepostUsername { get; set; }

        [DataMember]
        public DateTime RepostTime { get; set; }

        [DataMember]
        public int assess_good { get; set; }

        [DataMember]
        public int assess_bad { get; set; }

        [DataMember]
        public int to_coin { get; set; }

        [DataMember]
        public int to_coin_ed { get; set; }

        [DataMember]
        public int task_state { get; set; }

        [DataMember]
        public int get_coin { get; set; }

        [DataMember]
        public int bbs_lock { get; set; }

        [DataMember]
        public string bbs_lock_info { get; set; }

        [DataMember]
        public string bbs_edit_info { get; set; }

        [DataMember]
        public string title_color { get; set; }

        [DataMember]
        public string title_bgcolor { get; set; }

        [DataMember]
        public string title_bold { get; set; }

        [DataMember]
        public DateTime bbs_lock_time { get; set; }

        [DataMember]
        public DateTime bbs_notshow_time { get; set; }

        [DataMember]
        public DateTime bbs_istop_time { get; set; }

        [DataMember]
        public int coin_link { get; set; }

        [DataMember]
        public int bbsgood { get; set; }

        [DataMember]
        public int bbstop { get; set; }

        [DataMember]
        public int ispoll { get; set; }

        [DataMember]
        public int poll_days { get; set; }

        [DataMember]
        public int poll_type { get; set; }

        [DataMember]
        public int poll_maxvote { get; set; }

        [DataMember]
        public int poll_open { get; set; }

        [DataMember]
        public int stand { get; set; }

        [DataMember]
        public int goodkey { get; set; }

        [DataMember]
        public int fid { get; set; }

        [DataMember]
        public string blogurl { get; set; }

        [DataMember]
        public int ArticleID { get; set; }

        [DataMember]
        public int ParkID { get; set; }

    }
}