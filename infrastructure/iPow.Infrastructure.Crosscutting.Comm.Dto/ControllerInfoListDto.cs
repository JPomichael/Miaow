using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using System.Runtime.Serialization;

namespace iPow.Infrastructure.Crosscutting.Comm.Dto
{
    [Serializable]
    [DataContract]
    public class ControllerInfoListDto
    {
        /// <summary>
        /// Gets or sets the type of the contorller.
        /// </summary>
        /// <value>The type of the contorller.</value>
        [DataMember]
        [DisplayName("控制器类型")]
        public Type ContorllerType { get; set; }

        /// <summary>
        /// Gets or sets the name of the action method.
        /// </summary>
        /// <value>The name of the action method.</value>
        [DataMember]
        [DisplayName("Action列表")]
        public List<string> ActionNameList { get; set; }
    }
}
