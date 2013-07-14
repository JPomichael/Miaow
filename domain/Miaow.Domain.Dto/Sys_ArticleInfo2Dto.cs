using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class Sys_ArticleInfo2Dto
    {
        [DataMember]
        public int ArticleID { get; set; }

        [DataMember]
        public int ClassID { get; set; }

        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public int PicID { get; set; }

        [DataMember]
        public string PicUrl { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string SubTitle { get; set; }

        [DataMember]
        public string Tag { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public int CommFlag { get; set; }

        [DataMember]
        public DateTime AddTime { get; set; }

        [DataMember]
        public int VisitCount { get; set; }

        [DataMember]
        public int IsTop { get; set; }

        [DataMember]
        public DateTime TopTime { get; set; }

        [DataMember]
        public int IsVouch { get; set; }

        [DataMember]
        public DateTime VouchTime { get; set; }

        [DataMember]
        public int IsDelete { get; set; }

        [DataMember]
        public int IsAud { get; set; }

        [DataMember]
        public DateTime AudTime { get; set; }

        [DataMember]
        public DateTime DeleteTime { get; set; }

        [DataMember]
        public int SightID { get; set; }

        [DataMember]
        public string ArticleUrl { get; set; }

        [DataMember]
        public string Source { get; set; }

    }
}