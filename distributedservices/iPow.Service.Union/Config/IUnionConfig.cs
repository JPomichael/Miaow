using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Service.Union.Config
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnionConfig
    {

        /// <summary>
        /// Initials this instance.
        /// </summary>
        /// <returns></returns>
        iPow.Application.Union.Dto.UnionConfigDto Initial();
    }
}