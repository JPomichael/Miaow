using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_userpetDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int userid { get; set; }

        [DataMember]
        public int petid { get; set; }

        [DataMember]
        public string pet_user_name { get; set; }

        [DataMember]
        public int pet_HP { get; set; }

        [DataMember]
        public int pet_MP { get; set; }

        [DataMember]
        public int pet_CP { get; set; }

        [DataMember]
        public string pet_img { get; set; }

        [DataMember]
        public string pet_happy_img { get; set; }

        [DataMember]
        public string pet_blue_img { get; set; }

        [DataMember]
        public int pet_exp { get; set; }

        [DataMember]
        public int pet_lev { get; set; }

        [DataMember]
        public int pet_heart { get; set; }

        [DataMember]
        public int pet_point { get; set; }

    }
}