using System.Runtime.Serialization;

namespace iPow.Service.SSO.Entity
{
    [DataContract]
    public class SingleSignOnFault
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [DataMember]
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        [DataMember]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the stack trace.
        /// </summary>
        /// <value>The stack trace.</value>
        [DataMember]
        public string StackTrace { get; set; }

        /// <summary>
        /// Gets or sets the help link.
        /// </summary>
        /// <value>The help link.</value>
        [DataMember]
        public string HelpLink { get; set; }
    }
}
