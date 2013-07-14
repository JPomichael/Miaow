using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class Survey_CompanyInfoDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CompanyName { get; set; }

        [DataMember]
        public string ContactorName { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public bool State { get; set; }

        [DataMember]
        public DateTime AddTime { get; set; }

    }
}