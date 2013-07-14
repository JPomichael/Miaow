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
    [DisplayName("Sys_HotelDailyRates")]
	
	public class Sys_HotelDailyRatesDto
	{
   		     
      		
        [DataMember]
        [DisplayName("һֱΪNULL")]
        public int DailyRatesID  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("�Ƶ�ID��")]
        public int HotelID  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("��������")]
        public string RoomType  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("������")]
        public string RoomName  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("���䱸ע")]
        public string RoomDescription  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("һ��Ϊ��")]
        public int Allotment  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("һ��Ϊ��")]
        public int LeadTime  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("һ��Ϊ��")]
        public int MinLos  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("һ��Ϊ��")]
        public int MaxLos  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("DoubleRates")]
        public string DoubleRates  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("һ��Ϊ��")]
        public string GUA  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("һ��Ϊ��")]
        public string CXL  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("һ��Ϊ��")]
        public string RateCode  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("һ��Ϊ��")]
        public int MaxOccupancy  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("��Դ")]
        public string Source  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("RoomAmountAdvice")]
        public string RoomAmountAdvice  {get ;set; }
        
            
                    
		   
	}
}