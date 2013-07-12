using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class Sys_CityInfo2Dto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string PinYin { get; set; }

        [DataMember]
        public string Py { get; set; }

        [DataMember]
        public string PostCode { get; set; }

        [DataMember]
        public string AearName { get; set; }

        [DataMember]
        public decimal Latitude { get; set; }

        [DataMember]
        public decimal Longitude { get; set; }

        [DataMember]
        public string Province { get; set; }

        [DataMember]
        public string ProvincePy { get; set; }

        [DataMember]
        public DateTime AddTime { get; set; }

        [DataMember]
        public bool State { get; set; }
    }
}