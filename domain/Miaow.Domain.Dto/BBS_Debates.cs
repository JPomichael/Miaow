using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_DebatesDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int userid { get; set; }

        [DataMember]
        public string starttime { get; set; }

        [DataMember]
        public string endtime { get; set; }

        [DataMember]
        public int affirmdebaters { get; set; }

        [DataMember]
        public int negadebaters { get; set; }

        [DataMember]
        public int affirmvotes { get; set; }

        [DataMember]
        public int negavotes { get; set; }

        [DataMember]
        public string affirmpoint { get; set; }

        [DataMember]
        public string negapoint { get; set; }

        [DataMember]
        public int winner { get; set; }

        [DataMember]
        public int umpire { get; set; }

        [DataMember]
        public int bestdebater { get; set; }

        [DataMember]
        public int bbsid { get; set; }

        [DataMember]
        public int boardid { get; set; }

    }
}