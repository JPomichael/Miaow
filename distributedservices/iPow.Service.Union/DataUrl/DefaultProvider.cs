using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using iPow.Service.Union.Config;
using System.Collections.Specialized;

namespace iPow.Service.Union.DataUrl.Default
{

    #region 酒店介绍

    /// <summary>
    /// 酒店介绍
    /// hotel_id={0}
    /// UrlParas.Add("hotel_id" , "11384");
    /// </summary>
    public class HotelInfoDefaultService : UnionDataUrlBase
    {
        public HotelInfoDefaultService()
        {
            UrlSource = "hotel_info/?";
        }

        public HotelInfoDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "hotel_info/?";
        }
    }


    #endregion

    #region 获得首页主推酒店 人气酒店推荐

    /// <summary>
    /// 获得首页主推酒店 人气酒店推荐
    /// cid={cid}&type_id={typeid}
    /// </summary>
    public class IndexHotelDefaultService : UnionDataUrlBase
    {
        public IndexHotelDefaultService()
        {
            UrlSource = "hotel/?";
        }

        public IndexHotelDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "hotel/?";
        }
    }


    #endregion

    #region 获得某个城市的所有连锁品牌

    /// <summary>
    /// 获得某个城市的所有连锁品牌
    /// cid={cid}
    /// </summary>
    public class AllChainDefaultService : UnionDataUrlBase
    {
        public AllChainDefaultService()
        {
            UrlSource = "allchain/?";
        }

        public AllChainDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "allchain/?";
        }
    }

    #endregion

    #region 获得某个品牌的所有城市

    /// <summary>
    /// 获得某个品牌的所有城市
    /// chain={chain}
    /// </summary>
    public class ChainInfoDefaultService : UnionDataUrlBase
    {
        public ChainInfoDefaultService()
        {
            UrlSource = "chain_info/?";
        }

        public ChainInfoDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "chain_info/?";
        }
    }

    #endregion

    #region 获得酒店点评

    /// <summary>
    /// 获得酒店点评
    /// hotelid={hotelid}&cid={cid}&px={pg}&type={type}
    /// </summary>
    public class HotelDianPingListDefaultService : UnionDataUrlBase
    {
        public HotelDianPingListDefaultService()
        {
            UrlSource = "hotel_dianpinglist/?";
        }

        public HotelDianPingListDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "hotel_dianpinglist/?";
        }
    }
    #endregion

    #region 获得城市的大学和中学，1为大学，2为中学

    /// <summary>
    /// 获得城市的大学和中学，1为大学，2为中学
    /// cid={cid}&type_id={typeid}
    /// </summary>
    public class SchoolCityDefaultService : UnionDataUrlBase
    {
        public SchoolCityDefaultService()
        {
            UrlSource = "school_city/?";
        }

        public SchoolCityDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "school_city/?";
        }
    }

    #endregion

    #region 获得搜索关键字的经纬度

    /// <summary>
    /// 获得搜索关键字的经纬度
    /// cid={cid}&type_name={str}
    /// </summary>
    public class SinglePosDefaultService : UnionDataUrlBase
    {
        public SinglePosDefaultService()
        {
            UrlSource = "getsinglepos/?";
        }

        public SinglePosDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "getsinglepos/?";
        }
    }

    #endregion

    #region 酒店的周边环境

    /// <summary>
    /// 酒店的周边环境
    /// cid={cid}&hid={hid}&pos={pos}&type_id={typeid}&num={num}
    /// </summary>
    public class ScenicsPotsDefaultService : UnionDataUrlBase
    {
        public ScenicsPotsDefaultService()
        {
            UrlSource = "hotel_round/?";
        }

        public ScenicsPotsDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "hotel_round/?";
        }
    }

    #endregion

    #region 酒店的周边酒店

    /// <summary>
    /// 酒店的周边环境
    /// cid={cid}&hid={hid}&pos={pos}&lowprice={lowprice}
    /// </summary>
    public class HotelAroundDefaultService : UnionDataUrlBase
    {
        public HotelAroundDefaultService()
        {
            UrlSource = "around/?";
        }

        public HotelAroundDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "around/?";
        }
    }

    #endregion

    #region 酒店图片

    /// <summary>
    /// 酒店图片
    /// hotel_id={hotelid}
    /// </summary>
    public class HotelPicDefaultService : UnionDataUrlBase
    {
        public HotelPicDefaultService()
        {
            UrlSource = "hotel_pic/?";
        }

        public HotelPicDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "hotel_pic/?";
        }
    }

    #endregion

    #region 获得专栏相关的数据 这个有点特别哦，调的时候，注意下，没有参数

    /// <summary>
    /// 获得专栏相关的数据
    /// 这个有点特别哦，调的时候，注意下，没有参数
    /// {type_name}/?
    /// </summary>
    public class ZhuanTiListDefaultService : UnionDataUrlBase
    {
        public ZhuanTiListDefaultService()
        {
            UrlSource = "{type_name}/?";
        }

        public ZhuanTiListDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "{type_name}/?";
        }
    }
    #endregion

    #region 最新酒店点评(最多10条) 这个有点特别哦，调的时候，注意下，没有参数

    /// <summary>
    /// 最新酒店点评(最多10条)
    /// 这个有点特别哦，调的时候，注意下，没有参数
    /// </summary>
    public class NewDianPingDefaultService : UnionDataUrlBase
    {
        public NewDianPingDefaultService()
        {
            UrlSource = "newdianping/?";
        }

        public NewDianPingDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "newdianping/?";
        }
    }

    #endregion

    #region 最新酒店问答(最多10条) 这个有点特别哦，调的时候，注意下，没有参数

    /// <summary>
    /// 最新酒店问答(最多10条)
    /// 这个有点特别哦，调的时候，注意下，没有参数
    /// </summary>
    public class NewAskDefaultService : UnionDataUrlBase
    {
        public NewAskDefaultService()
        {
            UrlSource = "newask/?";
        }

        public NewAskDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "newask/?";
        }
    }

    #endregion

    #region 最新酒店订单(最多10条) 这个有点特别哦，调的时候，注意下，没有参数

    /// <summary>
    /// 最新酒店订单(最多10条)
    /// 这个有点特别哦，调的时候，注意下，没有参数
    /// </summary>
    public class NewDingDanDefaultService : UnionDataUrlBase
    {
        public NewDingDanDefaultService()
        {
            UrlSource = "newdingdan/?";
        }

        public NewDingDanDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "newdingdan/?";
        }
    }

    #endregion

    #region 该城市有视频的酒店列表

    /// <summary>
    /// 该城市有视频的酒店列表
    /// cid={cid}
    /// </summary>
    public class VideoListDefaultService : UnionDataUrlBase
    {
        public VideoListDefaultService()
        {
            UrlSource = "vedio/?";
        }

        public VideoListDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "hotel_pic/?";
        }
    }

    #endregion

    #region 问答列表

    /// <summary>
    /// 问答列表
    /// hotelid={hotelid}&cid={cid}&page={page}
    /// </summary>
    public class AskListDefaultService : UnionDataUrlBase
    {
        public AskListDefaultService()
        {
            UrlSource = "ask/?";
        }

        public AskListDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "hotel_pic/?";
        }
    }

    #endregion

    #region 订单查询接口


    /// <summary>
    /// 订单查询接口
    /// </summary>
    public class DingDanlistDefaultService : UnionDataUrlBase
    {
        //dingdanlist:b+"dingdanlist/?phone={phone}&typeid=0206",
        public DingDanlistDefaultService()
        {
            UrlSource = "dingdanlist/?";
        }

        public DingDanlistDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "dingdanlist/?";
        }
    }

    #endregion

    #region 查询所有的城市

    /// <summary>
    /// 查询所有的城市
    /// 这个有点特别哦，调的时候，注意下，没有参数
    /// </summary>
    public class QueryAllCityDefaultService : UnionDataUrlBase
    {
        public QueryAllCityDefaultService()
        {
            UrlSource = "allcity/?";
        }

        public QueryAllCityDefaultService(IUnionConfig fig)
            : base(fig)
        {
             UrlSource = "allcity/?";
        }
    }

    #endregion

    #region 酒店搜索

    /// <summary>
    /// 酒店搜索
    /// t1=2011_11_18&cid=21&rid=&jdwz=0&jdlx=0&chain=0&key_name=%C9%EE%DB%DA&pg=1&px=4&p1=0&p2=0&pos=&agent_id=112935&agent_md=O81U21UM11.html
    /// </summary>
    public class HotelSearchDefaultService : UnionDataUrlBase
    {
        public HotelSearchDefaultService()
        {
            UrlSource = "hotel_list/?";
        }

        public HotelSearchDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "hotel_list/?";
        }
    }

    #endregion

    #region 酒店搜索提示

    /// <summary>
    /// 酒店搜索提示
    /// http://data.128uu.com/data/search.asp?callback=KISSY.Suggest.callback&cid=20&q=%E5%A6%82%E5%AE%B6
    /// </summary>
    public class HotelSearchTipDefaultService : UnionDataUrlBase
    {
        public HotelSearchTipDefaultService()
        {
            UrlSource = "search.asp";
        }

        public HotelSearchTipDefaultService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "search.asp";
        }
    }

    #endregion

}