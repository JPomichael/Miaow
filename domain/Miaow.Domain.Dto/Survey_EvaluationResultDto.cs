using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class Survey_EvaluationResultDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Guid { get; set; }

        [DataMember]
        public int ItemId { get; set; }

        [DataMember]
        public int ItemResultId { get; set; }

        [DataMember]
        public bool State { get; set; }

        [DataMember]
        public DateTime AddTime { get; set; }

    }
}