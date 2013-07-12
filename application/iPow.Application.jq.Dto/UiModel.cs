using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Application.jq.Dto
{
    //2011.8.2.17.18 ,添加了首页的类，不能再用数据库模型了
    #region 首页用到

    /// <summary>
    /// 用于前面上面的分类的哈
    /// added by yjihrp 2011.5...
    /// </summary>
    public class TopClassDto
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>The count.</value>
        public int count { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public int Type { get; set; }

    }

    /// <summary>
    /// added by yjihrp 2011.8.2.17.18
    /// 首页用的，右边的文件列表类
    /// </summary>
    public class DefaultRightArticleListDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the add time.
        /// </summary>
        /// <value>The add time.</value>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        /// <value>The sid.</value>
        public int? Sid { get; set; }
    }


    /// <summary>
    /// added by yjihrp 2011.8.3.15.49
    /// 首页用到的景区类 后面省页面会继承这个类的
    /// </summary>
    public class DefaultSightInfoDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int ParkID { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the vouch.
        /// </summary>
        /// <value>The vouch.</value>
        public double? VoIndex { get; set; }

        /// <summary>
        /// Gets or sets the gone.
        /// </summary>
        /// <value>The gone.</value>
        public int? WantCount { get; set; }

        /// <summary>
        /// Gets or sets the ticket.
        /// </summary>
        /// <value>The ticket.</value>
        public int? Ticket { get; set; }

        /// <summary>
        /// Gets or sets the DES.
        /// </summary>
        /// <value>The DES.</value>
        public string Remark { get; set; }

        /// <summary>
        /// Gets or sets the py.
        /// </summary>
        /// <value>The py.</value>
        public string Py { get; set; }

        /// <summary>
        /// Gets or sets the province.
        /// </summary>
        /// <value>The province.</value>
        public string Province { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the sort province.
        /// </summary>
        /// <value>The sort province.</value>
        public string SortProv { get; set; }

        /// <summary>
        /// Gets or sets the sort city.
        /// </summary>
        /// <value>The sort city.</value>
        public string SortCity { get; set; }

        /// <summary>
        /// Gets or sets the is sort.
        /// </summary>
        /// <value>The is sort.</value>
        public int IsSort { get; set; }

        /// <summary>
        /// Gets or sets the vi count.
        /// </summary>
        /// <value>The vi count.</value>
        public int ViCount { get; set; }

        /// <summary>
        /// Gets or sets the go count.
        /// </summary>
        /// <value>The go count.</value>
        public int? GoCount { get; set; }

        /// <summary>
        /// Gets or sets the is short.
        /// </summary>
        /// <value>The is short.</value>
        public int? IsShort { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        #region

        // added by yjihrp 2011.8.3.15.30
        /// <summary>
        /// Gets or sets the comm count.
        /// 省页用到
        /// </summary>
        /// <value>The comm count.</value>
        public int CommCount { get; set; }

        /// <summary>
        /// Gets or sets the pic count.
        /// 省页用到
        /// </summary>
        /// <value>The pic count.</value>
        public int PicCount { get; set; }
        //end added by yjihrp 2011.8.3.15.30
        #endregion

        #region

        // added by yjihrp 2011.8.4.10.27
        /// <summary>
        /// Gets or sets the city py.
        /// 详细页可能用到
        /// 首页可能用到
        /// </summary>
        /// <value>The city py.</value>
        public string CityPy { get; set; }

        /// <summary>
        /// Gets or sets the prov py.
        /// 详细页可能用到
        /// 首页可能用到
        /// </summary>
        /// <value>The prov py.</value>
        public string ProvPy { get; set; }

        /// <summary>
        /// Gets or sets the lat.
        /// 详细页可能用到
        /// 首页可能用到
        /// </summary>
        /// <value>The lat.</value>
        public double? Lat { get; set; }

        /// <summary>
        /// Gets or sets the long.
        /// 详细页可能用到
        /// 首页可能用到
        /// </summary>
        /// <value>The long.</value>
        public double? Long { get; set; }

        #endregion

        #region
        /// <summary>
        /// Gets or sets the URL.
        /// 搜索页用到
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        #endregion
    }


    #endregion

    #region 详细页

    /// <summary>
    /// 详细页的基类
    /// </summary>
    public class DetailSightBaseDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int ParkID { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the py.
        /// </summary>
        /// <value>The py.</value>
        public string Py { get; set; }

        /// <summary>
        /// Gets or sets the ticket.
        /// </summary>
        /// <value>The ticket.</value>
        public int? Ticket { get; set; }

        /// <summary>
        /// Gets or sets the want count.
        /// </summary>
        /// <value>The want count.</value>
        public int? WantCount { get; set; }

        /// <summary>
        /// Gets or sets the go count.
        /// </summary>
        /// <value>The go count.</value>
        public int? GoCount { get; set; }

        /// <summary>
        /// Gets or sets the park map.
        /// </summary>
        /// <value>The park map.</value>
        public string ParkMap { get; set; }
    }


    #endregion
}
