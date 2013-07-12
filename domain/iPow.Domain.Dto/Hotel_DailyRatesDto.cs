using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class Hotel_DailyRatesDto
    {
        [DataMember]
        public string DailyRatesID { get; set; }

        [DataMember]
        public int HotelID { get; set; }

        [DataMember]
        public string RoomType { get; set; }

        [DataMember]
        public string RoomName { get; set; }

        [DataMember]
        public string RoomDescription { get; set; }

        [DataMember]
        public int Allotment { get; set; }

        [DataMember]
        public int LeadTime { get; set; }

        [DataMember]
        public int MinLos { get; set; }

        [DataMember]
        public int MaxLos { get; set; }

        [DataMember]
        public string DoubleRates { get; set; }

        [DataMember]
        public string GUA { get; set; }

        [DataMember]
        public string CXL { get; set; }

        [DataMember]
        public string RateCode { get; set; }

        [DataMember]
        public int MaxOccupancy { get; set; }

    }
}