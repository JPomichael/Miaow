using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Application.dj.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHomeService
    {
        /// <summary>
        /// Gets the home model.
        /// </summary>
        /// <param name="pi">The pi.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        Dto.HomeDto GetHomeModel(int? pi, int? take);
    }
}
