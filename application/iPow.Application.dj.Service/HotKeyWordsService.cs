using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace iPow.Application.dj.Service
{
    public class HotKeyWordsService : IHotKeyWordsService
    {
        iPow.Domain.Repository.ISearchInfoRepository searchInfoRepository = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotKeyWordsService"/> class.
        /// </summary>
        /// <param name="searchInfo">The search info.</param>
        public HotKeyWordsService(iPow.Domain.Repository.ISearchInfoRepository searchInfo)
        {
            if (searchInfo == null)
            {
                throw new ArgumentNullException("searchInfoRepository is null");
            }
            searchInfoRepository = searchInfo;
        }

        /// <summary>
        /// Gets the hot key words list.
        /// </summary>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public List<string> GetHotKeyWordsList(int take)
        {
            List<string> data = new List<string>();
            data = searchInfoRepository.GetList().GroupBy(e => e.KeyWord).Select(e => e.Key).Take(take).ToList();
            return data;
        }
    }
}
