using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class Sys_phoneCountLogDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Ip { get; set; }

        [DataMember]
        public DateTime Time { get; set; }

        [DataMember]
        public int type { get; set; }

    }
}