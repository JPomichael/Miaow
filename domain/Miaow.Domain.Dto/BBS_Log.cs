using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_LogDto
    {
        [DataMember]
        public int LogID { get; set; }

        [DataMember]
        public DateTime LogDate { get; set; }

        [DataMember]
        public string Thread { get; set; }

        [DataMember]
        public string Level { get; set; }

        [DataMember]
        public string Logger { get; set; }

        [DataMember]
        public string Message { get; set; }

    }
}