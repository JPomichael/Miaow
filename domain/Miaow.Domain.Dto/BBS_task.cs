using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_taskDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string task_title { get; set; }

        [DataMember]
        public string task_content { get; set; }

        [DataMember]
        public string task_link { get; set; }

        [DataMember]
        public string task_key { get; set; }

        [DataMember]
        public int task_lev { get; set; }

        [DataMember]
        public int task_money { get; set; }

        [DataMember]
        public int task_win_count { get; set; }

        [DataMember]
        public int task_lost_count { get; set; }

    }
}