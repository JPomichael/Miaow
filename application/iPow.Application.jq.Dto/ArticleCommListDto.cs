using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using iPow.Domain.Dto;

namespace iPow.Application.jq.Dto
{
    public class ArticleCommListDto
    {
        /// <summary>
        /// Gets or sets the comm list.
        /// 文章评论列表
        /// </summary>
        /// <value>The comm list.</value>
        public Webdiyer.WebControls.Mvc.PagedList<Sys_ArticleCommDto> CommList { get; set; }

        /// <summary>
        /// Gets or sets the article id.
        /// </summary>
        /// <value>The article id.</value>
        public int ArticleId { get; set; }
    }
}