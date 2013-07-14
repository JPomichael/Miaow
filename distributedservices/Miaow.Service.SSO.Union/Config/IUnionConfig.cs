using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Miaow.Service.Union.Config
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
        Miaow.Application.Union.Dto.UnionConfigDto Initial();
    }
}