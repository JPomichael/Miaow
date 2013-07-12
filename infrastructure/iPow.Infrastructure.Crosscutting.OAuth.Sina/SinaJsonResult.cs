using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Infrastructure.Crosscutting.OAuth.Sina
{
    /// <summary>
    /// 
    /// </summary>
    public class SinaJsonResult
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SinaJsonResult"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// 
        /// </summary>
        /// <value>The user.</value>
        public string User { get; set; }


        /// <summary>
        /// Gets or sets the issin.
        /// </summary>
        /// <value>The issin.</value>
        public int Issin { get; set; }

        //   public Model.szlybeer BeerModel { get; set; }
    }
}