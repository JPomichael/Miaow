using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_poll_optionsDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int boardid { get; set; }

        [DataMember]
        public int bbsid { get; set; }

        [DataMember]
        public string poll_option { get; set; }

        [DataMember]
        public int votes { get; set; }

        [DataMember]
        public int px { get; set; }

    }
}