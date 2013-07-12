using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_petDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string pet_name { get; set; }

        [DataMember]
        public int pet_HP { get; set; }

        [DataMember]
        public int pet_MP { get; set; }

        [DataMember]
        public int pet_CP { get; set; }

        [DataMember]
        public string pet_img { get; set; }

        [DataMember]
        public string pet_happy_img { get; set; }

        [DataMember]
        public string pet_blue_img { get; set; }

        [DataMember]
        public string pet_info { get; set; }

        [DataMember]
        public int pet_buys { get; set; }

        [DataMember]
        public int pet_price { get; set; }

    }
}