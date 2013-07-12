using System;
namespace Wbm.TencV2SDK.Models
{
    /// <summary>
    /// 公司信息实体类
    /// </summary>
    [Serializable]
    public class TencMComp 
    {
        /// <summary>
        /// 开始年
        /// </summary>
        public int begin_year { set; get; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string company_name { set; get; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string department_name { set; get; }

        /// <summary>
        /// 结束年
        /// </summary>
        public int end_year { set; get; }

        /// <summary>
        /// 公司id
        /// </summary>
        public string id { set; get; }

    }

}
/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */