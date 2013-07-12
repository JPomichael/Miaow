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
    public class SinaMUserList
    {
        public SinaMUserList()
        { }
        #region Model
        /// <summary>
        /// 用户列表 
        /// </summary>
        public List<SinaMUser> users { set; get; }

        /// <summary>
        /// 下一页用返回值里的next_cursor
        /// </summary>
        public int next_cursor { set; get; }

        /// <summary>
        /// 上一页用previous_cursor
        /// </summary>
        public int previous_cursor { set; get; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int total_number { set; get; }
        #endregion Model

    }
}

