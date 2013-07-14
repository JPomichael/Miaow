using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_UserPropDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int userid { get; set; }

        [DataMember]
        public int propid { get; set; }

        [DataMember]
        public int prop_num { get; set; }

    }
}