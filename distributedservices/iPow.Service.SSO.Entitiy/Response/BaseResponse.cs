using System.Runtime.Serialization;

namespace iPow.Service.SSO.Entity
{
    [DataContract]
    public class BaseResponse
    {
        /// <summary>
        /// Gets or sets the fault.
        /// </summary>
        /// <value>The fault.</value>
        [DataMember]
        public SingleSignOnFault Fault { get; set; }
    }
}
