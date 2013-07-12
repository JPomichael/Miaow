using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_pet_levDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string pet_lev_name { get; set; }

        [DataMember]
        public int pet_lev_exp { get; set; }

    }
}