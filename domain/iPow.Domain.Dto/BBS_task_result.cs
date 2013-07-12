using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_task_resultDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int userid { get; set; }

        [DataMember]
        public int taskid { get; set; }

        [DataMember]
        public DateTime addtime { get; set; }

        [DataMember]
        public string addip { get; set; }

    }
}