using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_gradeDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string grade { get; set; }

        [DataMember]
        public int grade_bbscount { get; set; }

        [DataMember]
        public string grade_img { get; set; }

    }
}