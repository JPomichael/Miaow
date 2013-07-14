using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_todayDto
    {
        [DataMember]
        public DateTime bbs_today { get; set; }

    }
}