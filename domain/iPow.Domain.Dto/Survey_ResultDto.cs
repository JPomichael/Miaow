using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class Survey_ResultDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string EvaluatioinResultGuid { get; set; }

        [DataMember]
        public string VoteTeamGuid { get; set; }

        [DataMember]
        public string Report { get; set; }

        [DataMember]
        public string YunWei { get; set; }

        [DataMember]
        public string Ipad { get; set; }

        [DataMember]
        public string Ip { get; set; }

        [DataMember]
        public bool State { get; set; }

        [DataMember]
        public DateTime AddTime { get; set; }

    }
}