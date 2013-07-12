using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Service.Union.Config
{
    public class DefaultUnionConfig : IUnionConfig
    {
        /// <summary>
        /// Inits this instance.
        /// </summary>
        /// <returns></returns>
        public iPow.Application.Union.Dto.UnionConfigDto Initial()
        {
            iPow.Application.Union.Dto.UnionConfigDto fig = new iPow.Application.Union.Dto.UnionConfigDto();
            fig.a = "/";
            fig.WebPath = "/";
            fig.WebName = "互动旅行网";
            fig.BaseUrl = "http://data.128uu.com/data/";
            fig.IsStaticPage = true;
            fig.DingDanType = "0206";
            fig.Version = "2.0";
            fig.CacheDay = "10";
            fig.AgentId = "160831";
            fig.AgentMd = "10OCU2U2MC";
            return fig;
        }
    }
}