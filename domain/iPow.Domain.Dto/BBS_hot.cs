using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_hotDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int boardid { get; set; }

        [DataMember]
        public int hot_type { get; set; }

        [DataMember]
        public string hot_color { get; set; }

        [DataMember]
        public string hot_title { get; set; }

        [DataMember]
        public string hot_link { get; set; }

        [DataMember]
        public string hot_img { get; set; }

        [DataMember]
        public string adduser { get; set; }

        [DataMember]
        public DateTime addtime { get; set; }

        [DataMember]
        public string addip { get; set; }

    }
}