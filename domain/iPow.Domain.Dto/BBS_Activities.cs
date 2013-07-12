using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_ActivitiesDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int fid { get; set; }

        [DataMember]
        public int cost { get; set; }

        [DataMember]
        public string starttime { get; set; }

        [DataMember]
        public string endtime { get; set; }

        [DataMember]
        public string place { get; set; }

        [DataMember]
        public string classes { get; set; }

        [DataMember]
        public int gender { get; set; }

        [DataMember]
        public int number { get; set; }

        [DataMember]
        public string expiration { get; set; }

        [DataMember]
        public int userid { get; set; }

        [DataMember]
        public string city { get; set; }

        [DataMember]
        public int isindex { get; set; }

    }
}