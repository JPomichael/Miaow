using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_adDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string place_name { get; set; }

        [DataMember]
        public int place_type { get; set; }

        [DataMember]
        public int place_price { get; set; }

        [DataMember]
        public int img_width { get; set; }

        [DataMember]
        public int img_height { get; set; }

        [DataMember]
        public string place_default { get; set; }

        [DataMember]
        public string place_explain { get; set; }

    }
}