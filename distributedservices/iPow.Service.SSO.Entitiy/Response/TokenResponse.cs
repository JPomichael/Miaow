
using System.Runtime.Serialization;
namespace iPow.Service.SSO.Entity
{
    [DataContract]
    public class TokenResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        [DataMember]
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        [DataMember]
        public Token Token { get; set; }
    }
}
