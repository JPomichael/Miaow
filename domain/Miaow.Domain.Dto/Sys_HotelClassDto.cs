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
    [DisplayName("Sys_HotelClass")]
	
	public class Sys_HotelClassDto
	{
   		     
      		
        [DataMember]
        [DisplayName("����ID��")]
        public int ClassID  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("������")]
        public string ClassName  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("������ID")]
        public int ParentID  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("ClassPath")]
        public string ClassPath  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("ClassDepth")]
        public int ClassDepth  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("ClassOrder")]
        public int ClassOrder  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("˵��")]
        public string ClassIntro  {get ;set; }
        
            
                    
			
        [DataMember]
        [DisplayName("ģ��ID")]
        public int DemoID  {get ;set; }
        
            
                    
		   
	}
}