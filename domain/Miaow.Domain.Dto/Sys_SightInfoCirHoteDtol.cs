using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.ComponentModel;
using System.Runtime.Serialization;
using FluentValidation;
using FluentValidation.Mvc;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    [DisplayName("Sys_SightInfoCirHotel")]
    public class Sys_SightInfoCirHotelDto
    {
        [DataMember]
        [DisplayName("自增ID号")]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("景区ID号")]
        public int SightId { get; set; }

        [DataMember]
        [DisplayName("酒店ID号")]
        public int HotelId { get; set; }

        [DataMember]
        [DisplayName("酒店来源")]
        public string Source { get; set; }

        [DataMember]
        [DisplayName("操作用户ID")]
        public int UserId { get; set; }

        [DataMember]
        [DisplayName("添加时间")]
        public DateTime AddTime { get; set; }
    }
}