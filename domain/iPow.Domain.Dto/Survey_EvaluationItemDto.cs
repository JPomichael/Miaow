using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class Survey_EvaluationItemDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int ItemTypeId { get; set; }

        [DataMember]
        public int ResultTypeId { get; set; }

        [DataMember]
        public bool State { get; set; }

        [DataMember]
        public DateTime Addtime { get; set; }

    }
}