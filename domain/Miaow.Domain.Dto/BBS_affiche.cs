using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_afficheDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string title { get; set; }

        [DataMember]
        public string content { get; set; }

        [DataMember]
        public string link { get; set; }

        [DataMember]
        public DateTime addtime { get; set; }

        [DataMember]
        public string addmaster { get; set; }

        [DataMember]
        public int hits { get; set; }

    }
}