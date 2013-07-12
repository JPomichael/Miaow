
using System.Runtime.Serialization;
namespace iPow.Service.SSO.Entity
{
    [DataContract]
    public class Token
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        [DataMember]
        public string TokenId { get; set; }
    }
}
