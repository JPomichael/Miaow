/*
 This file was create by Xusion at 2011.10.27
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using Wbm.SinaV2API.SinaServices;
using Wbm.SinaV2API.SinaModels;

namespace Wbm.SinaV2API.Helpers
{
    /// <summary>
    /// 错误对象
    /// </summary>
    public static class ApiErrorHelper
    {
        public static string IsSuccess(string strJson)
        {
            var code = HttpUtil.ParseJson<SinaMErrorCode>(strJson);
            if (code != null && code.error == 0)
            {
                return strJson;
            }
            throw new ArgumentException(strJson);
        }

    }
}
