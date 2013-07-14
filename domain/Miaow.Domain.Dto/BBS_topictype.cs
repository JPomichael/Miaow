using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_topictypeDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int boardid { get; set; }

        [DataMember]
        public string BBSTopic { get; set; }

        [DataMember]
        public string BBSTopicColor { get; set; }

        [DataMember]
        public int px { get; set; }

    }
}