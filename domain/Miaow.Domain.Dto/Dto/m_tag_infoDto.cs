//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.ComponentModel;
using System.Runtime.Serialization;
using Miaow.Domain.Dto.Validate;


namespace Miaow.Domain.Dto
{
    ////
    //using System.ComponentModel;
    //////using System.Runtime.Serialization;
    //
    /// <summary>
    /// m_tag_info
    /// </summary>
    [Serializable]
    [DataContract]
    [FluentValidation.Attributes.Validator(typeof(m_tag_infoDtoValidate))]
    public partial class m_tag_infoDto
    {
        #region Primitive Properties
    
        /// <summary>
        /// tag_id
        /// </summary>
    	[DataMember]
    	[DisplayName("tag_id")]
        public virtual int tag_id
        {
            get;
            set;
        }
    
        /// <summary>
        /// user_id
        /// </summary>
    	[DataMember]
    	[DisplayName("user_id")]
        public virtual string user_id
        {
            get;
            set;
        }
    
        /// <summary>
        /// tags
        /// </summary>
    	[DataMember]
    	[DisplayName("tags")]
        public virtual string tags
        {
            get;
            set;
        }
    
        /// <summary>
        /// createdtime
        /// </summary>
    	[DataMember]
    	[DisplayName("createdtime")]
        public virtual Nullable<System.DateTime> createdtime
        {
            get;
            set;
        }

        #endregion

    }
}