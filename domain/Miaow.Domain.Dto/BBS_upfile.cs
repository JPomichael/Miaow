using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_upfileDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int bbsid { get; set; }

        [DataMember]
        public int boardid { get; set; }

        [DataMember]
        public int userid { get; set; }

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string file_path { get; set; }

        [DataMember]
        public string file_name { get; set; }

        [DataMember]
        public string file_ext { get; set; }

        [DataMember]
        public int file_size { get; set; }

        [DataMember]
        public DateTime addtime { get; set; }

        [DataMember]
        public string addip { get; set; }

        [DataMember]
        public string bbstitle { get; set; }

        [DataMember]
        public string attachdesc { get; set; }

        [DataMember]
        public int isipow { get; set; }

        [DataMember]
        public int parkid { get; set; }

    }
}