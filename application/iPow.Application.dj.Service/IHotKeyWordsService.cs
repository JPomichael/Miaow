using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Application.dj.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHotKeyWordsService
    {
        /// <summary>
        /// Gets the hot key words list.
        /// </summary>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        List<string> GetHotKeyWordsList(int take);
    }
}
