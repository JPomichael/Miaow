using System.Runtime.Serialization;

namespace iPow.Service.SSO.Entity
{
    [DataContract]
    public class LoginResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        [DataMember]
        public User User { get; set; }
    }
}
