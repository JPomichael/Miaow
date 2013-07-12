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
        [DisplayName("一直为NULL")]
        public int DailyRatesID  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("酒店ID号")]
        public int HotelID  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("房间类型")]
        public string RoomType  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("房间名")]
        public string RoomName  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("房间备注")]
        public string RoomDescription  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("一般为空")]
        public int Allotment  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("一般为空")]
        public int LeadTime  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("一般为空")]
        public int MinLos  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("一般为空")]
        public int MaxLos  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("DoubleRates")]
        public string DoubleRates  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("一般为空")]
        public string GUA  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("一般为空")]
        public string CXL  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("一般为空")]
        public string RateCode  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("一般为空")]
        public int MaxOccupancy  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("来源")]
        public string Source  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("RoomAmountAdvice")]
        public string RoomAmountAdvice  {get ;set; }
        
            
                    
		   
	}
}