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
    [DisplayName("Sys_ChineseInfo")]
	public class Sys_ChineseInfoDto
	{
        [DataMember]
        [DisplayName("中文")]
        public string Chinese  {get ;set; }
 			
        [DataMember]
        [DisplayName("全拼")]
        public string QuanP  {get ;set; }
 			
        [DataMember]
        [DisplayName("五笔")]
        public string Code2  {get ;set; }
 			
        [DataMember]
        [DisplayName("缩拼全拼第一个字母")]
        public string SuoP  {get ;set; }
 			
        [DataMember]
        [DisplayName("五笔第一个字母")]
        public string Code4  {get ;set; }
	}
}