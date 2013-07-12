using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_ImgADDto
    {
        [DataMember]
        public string imgad_bbstop { get; set; }

        [DataMember]
        public string imgad_bbsbottom { get; set; }

        [DataMember]
        public string imgad_indexbanner { get; set; }

        [DataMember]
        public string imgad_listbanner1 { get; set; }

        [DataMember]
        public string imgad_listbanner2 { get; set; }

        [DataMember]
        public string imgad_rootbanner1 { get; set; }

        [DataMember]
        public string imgad_rootbanner2 { get; set; }

    }
}