using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Application.jq.Dto;

namespace iPow.Application.jq.Service
{
    public interface IArticleService
    {
        /// <summary>
        /// Gets the article class by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        iPow.Domain.Dto.Sys_ArticleClassDto GetArticleClassById(int id);

        /// <summary>
        /// Gets the article comm list by art id.
        /// </summary>
        /// <param name="artId">The art id.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        IQueryable<iPow.Domain.Dto.Sys_ArticleCommDto> GetArticleCommListByArtId(int? artId, int pageIndex, int take, ref int total);

        /// <summary>
        /// Gets the article comm single by id.
        /// </summary>
        /// <param name="commId">The comm id.</param>
        /// <returns></returns>
        iPow.Domain.Dto.Sys_ArticleCommDto GetArticleCommSingleById(int commId);

        /// <summary>
        /// Gets the article single by id.
        /// </summary>
        /// <param name="artId">The art id.</param>
        /// <returns></returns>
        iPow.Domain.Dto.Sys_ArticleInfoDto GetArticleSingleById(int? artId);

        /// <summary>
        /// Gets the sys article single by id.
        /// </summary>
        /// <param name="artId">The art id.</param>
        /// <returns></returns>
        iPow.Infrastructure.Data.DataSys.Sys_ArticleInfo GetSysArticleSingleById(int? artId);

        /// <summary>
        /// Gets the sight article by hot.
        /// </summary>
        /// <param name="sid">The sid.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        IQueryable<iPow.Domain.Dto.Sys_ArticleInfoDto> GetSightArticleByHot(int sid, int pageIndex, int take, ref int total);

        /// <summary>
        /// Gets the sight article by new.
        /// </summary>
        /// <param name="sid">The sid.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        IQueryable<iPow.Domain.Dto.Sys_ArticleInfoDto> GetSightArticleByNew(int sid, int pageIndex, int take, ref int total);

        /// <summary>
        /// Gets the sight article default page by prov.
        /// </summary>
        /// <param name="province">The province.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        IQueryable<DefaultRightArticleListDto> GetSightArticleDefaultPageByProv(string province, int take);


        /// <summary>
        /// Contents the split.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        List<string> ContentSplit(string content);

        /// <summary>
        /// Gets the article comm list by id.
        /// </summary>
        /// <param name="artId">The art id.</param>
        /// <param name="pi">The pi.</param>
        /// <param name="ps">The ps.</param>
        /// <returns></returns>
        ArticleCommListDto GetArticleCommListById(int? artId, int pi, int ps);

        /// <summary>
        /// Gets the article detail model.
        /// </summary>
        /// <param name="sightId">The sight id.</param>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        ArticleDetailDto GetArticleDetailModel(int? sightId, int? id);
    }
}
