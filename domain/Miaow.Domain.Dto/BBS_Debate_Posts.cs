using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_Debate_PostsDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int stand { get; set; }

        [DataMember]
        public int userid { get; set; }

        [DataMember]
        public int voters { get; set; }

        [DataMember]
        public int voterids { get; set; }

        [DataMember]
        public int tid { get; set; }

    }
}