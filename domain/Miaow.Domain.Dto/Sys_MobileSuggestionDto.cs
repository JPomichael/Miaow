using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class Sys_MobileSuggestionDto
    {
        [DataMember]
        public int CommId { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public string Ip { get; set; }

        [DataMember]
        public DateTime AddTime { get; set; }

        [DataMember]
        public int IsDelete { get; set; }

        [DataMember]
        public int State { get; set; }

    }
}