using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_reportDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int bbsid { get; set; }

        [DataMember]
        public int rootid { get; set; }

        [DataMember]
        public int boardid { get; set; }

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public int userid { get; set; }

        [DataMember]
        public string report_url { get; set; }

        [DataMember]
        public string report_content { get; set; }

        [DataMember]
        public DateTime addtime { get; set; }

        [DataMember]
        public string addip { get; set; }

        [DataMember]
        public int isok { get; set; }

    }
}