using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_TextADDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int placeid { get; set; }

        [DataMember]
        public string placename { get; set; }

        [DataMember]
        public string ad_text { get; set; }

        [DataMember]
        public string ad_color { get; set; }

        [DataMember]
        public string ad_bold { get; set; }

        [DataMember]
        public string ad_link { get; set; }

        [DataMember]
        public string ad_client { get; set; }

        [DataMember]
        public string ad_client_info { get; set; }

        [DataMember]
        public DateTime ad_stoptime { get; set; }

        [DataMember]
        public int px { get; set; }

    }
}