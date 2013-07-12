using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_LinkDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string link_type { get; set; }

        [DataMember]
        public string link_sitename { get; set; }

        [DataMember]
        public string link_site_url { get; set; }

        [DataMember]
        public string link_siter { get; set; }

        [DataMember]
        public string link_logo { get; set; }

        [DataMember]
        public int link_px { get; set; }

    }
}