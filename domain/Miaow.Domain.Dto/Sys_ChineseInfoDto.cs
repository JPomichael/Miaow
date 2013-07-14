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
        [DisplayName("����")]
        public string Chinese  {get ;set; }
 			
        [DataMember]
        [DisplayName("ȫƴ")]
        public string QuanP  {get ;set; }
 			
        [DataMember]
        [DisplayName("���")]
        public string Code2  {get ;set; }
 			
        [DataMember]
        [DisplayName("��ƴȫƴ��һ����ĸ")]
        public string SuoP  {get ;set; }
 			
        [DataMember]
        [DisplayName("��ʵ�һ����ĸ")]
        public string Code4  {get ;set; }
	}
}