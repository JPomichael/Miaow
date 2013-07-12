using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Application.dj.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// Gets the search tour model.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        IQueryable<Dto.SearchTourDto> GetSearchTourModel(Dto.SearchInfoDto search, int pageIndex, int take, ref int total);

        /// <summary>
        /// Gets the search tour model advanced.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <param name="day">The day.</param>
        /// <param name="type">The type.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        IQueryable<Dto.SearchTourDto> GetSearchTourModelAdvanced(string search,
              string sort, int min, int max, int day, List<string> type,
              int pageIndex, int take, ref int total);
    }
}
