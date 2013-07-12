/*
 This file was create by Xusion at 2011.10.27
 */
using System;
using System.Collections.Generic;
namespace Wbm.SinaV2API.SinaModels
{
    /// <summary>
    /// 实体类MUsers 。
    /// </summary>
    [Serializable]
    public class SinaMErrorCode
    {
        public SinaMErrorCode()
        { }
        #region Model
        /// <summary>
        /// 错误信息
        /// </summary>
        public int error { set; get; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public int error_code { set; get; }

        /// <summary>
        /// 详细描述
        /// </summary>
        public int error_description { set; get; }

        /// <summary>
        /// 请求地址
        /// </summary>
        public int request { set; get; }
        #endregion Model

    }
}

