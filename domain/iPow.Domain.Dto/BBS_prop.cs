using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_propDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string prop_name { get; set; }

        [DataMember]
        public string prop_explain { get; set; }

        [DataMember]
        public int prop_price { get; set; }

        [DataMember]
        public int prop_num { get; set; }

        [DataMember]
        public int prop_start { get; set; }

        [DataMember]
        public int prop_effect { get; set; }

        [DataMember]
        public int prop_use { get; set; }

        [DataMember]
        public int prop_group { get; set; }

    }
}