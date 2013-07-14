using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class Sys_PhoneRandTotalNumDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public decimal totalNum { get; set; }

    }
}