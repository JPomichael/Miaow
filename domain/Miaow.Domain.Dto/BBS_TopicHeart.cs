using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_TopicHeartDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string heart_name { get; set; }

        [DataMember]
        public string heart_img { get; set; }

        [DataMember]
        public string heart_ubb { get; set; }

    }
}