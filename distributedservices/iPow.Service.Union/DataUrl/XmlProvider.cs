using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using iPow.Service.Union.Config;
using System.Collections.Specialized;

namespace iPow.Service.Union.DataUrl.Xml
{
    #region 酒店介绍

    /// <summary>
    /// 酒店介绍
    /// </summary>
    public class HotelInfoXmlService : UnionDataUrlBase
    {
        public HotelInfoXmlService()
        {
        }

        public HotelInfoXmlService(IUnionConfig fig)
            : base(fig)
        {
        }

        public override Uri GetUrl()
        {
            var xmlPath = HttpContext.Current.Server.MapPath("~/DataUrlXmlProvider.xml");
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(xmlPath);
            System.Xml.XmlNode node = doc.SelectSingleNode("/root/dataurl[id=1]");
            iPow.Infrastructure.Crosscutting.Function.XmlHelper xml = new Infrastructure.Crosscutting.Function.XmlHelper(xmlPath);
            return base.GetUrl();
        }
    }

    #endregion

    #region 获得首页主推酒店

    /// <summary>
    /// 获得首页主推酒店
    /// cid={cid}&type_id={typeid}
    /// </summary>
    public class IndexHotelXmlService : UnionDataUrlBase
    {
        public IndexHotelXmlService()
        {
            UrlSource = "hotel/?";
        }

        public IndexHotelXmlService(IUnionConfig fig)
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
    public class AllChainXmlService : UnionDataUrlBase
    {

        public AllChainXmlService()
        {
            UrlSource = "allchain/?";
        }

        public AllChainXmlService(IUnionConfig fig)
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
    public class ChainInfoXmlService : UnionDataUrlBase
    {
        public ChainInfoXmlService()
        {
            UrlSource = "chain_info/?";
        }

        public ChainInfoXmlService(IUnionConfig fig)
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
    public class HotelDianPinglistXmlService : UnionDataUrlBase
    {
        public HotelDianPinglistXmlService()
        {
            UrlSource = "hotel_dianpinglist/?";
        }

        public HotelDianPinglistXmlService(IUnionConfig fig)
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
    public class SchoolCityXmlService : UnionDataUrlBase
    {
        public SchoolCityXmlService()
        {
            UrlSource = "school_city/?";
        }

        public SchoolCityXmlService(IUnionConfig fig)
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
    public class SinglePosXmlService : UnionDataUrlBase
    {
        public SinglePosXmlService()
        {
            UrlSource = "getsinglepos/?";
        }

        public SinglePosXmlService(IUnionConfig fig)
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
    public class ScenicsPotsXmlService : UnionDataUrlBase
    {
        public ScenicsPotsXmlService()
        {
            UrlSource = "hotel_round/?";
        }

        public ScenicsPotsXmlService(IUnionConfig fig)
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
    public class HotelAroundXmlService : UnionDataUrlBase
    {
        public HotelAroundXmlService()
        {
            UrlSource = "around/?";
        }

        public HotelAroundXmlService(IUnionConfig fig)
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
    public class HotelPicXmlService : UnionDataUrlBase
    {
        public HotelPicXmlService()
        {
            UrlSource = "hotel_pic/?";
        }

        public HotelPicXmlService(IUnionConfig fig)
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
    /// </summary>
    public class ZhuanTiListXmlService : UnionDataUrlBase
    {
        public ZhuanTiListXmlService()
        {
            UrlSource = "{type_name}/?";
        }

        public ZhuanTiListXmlService(IUnionConfig fig)
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
    public class NewDianPingXmlService : UnionDataUrlBase
    {
        public NewDianPingXmlService()
        {
            UrlSource = "newdianping/?";
        }

        public NewDianPingXmlService(IUnionConfig fig)
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
    public class NewAskXmlService : UnionDataUrlBase
    {
        public NewAskXmlService()
        {
            UrlSource = "newask/?";
        }

        public NewAskXmlService(IUnionConfig fig)
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
    public class NewDingDanXmlService : UnionDataUrlBase
    {
        public NewDingDanXmlService()
        {
            UrlSource = "newdingdan/?";
        }

        public NewDingDanXmlService(IUnionConfig fig)
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
    public class VideoListXmlService : UnionDataUrlBase
    {
        public VideoListXmlService()
        {
            UrlSource = "vedio/?";
        }

        public VideoListXmlService(IUnionConfig fig)
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
    public class AskListXmlService : UnionDataUrlBase
    {
        public AskListXmlService()
        {
            UrlSource = "ask/?";
        }

        public AskListXmlService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "ask/?";
        }
    }

    #endregion

    #region 订单查询接口


    /// <summary>
    /// 订单查询接口
    /// </summary>
    public class DingDanlistXmlService : UnionDataUrlBase
    {
        //dingdanlist:b+"dingdanlist/?phone={phone}&typeid=0206",
        public DingDanlistXmlService()
        {
            UrlSource = "dingdanlist/?";
        }

        public DingDanlistXmlService(IUnionConfig fig)
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
    public class QueryAllCityXmlService : UnionDataUrlBase
    {
        public QueryAllCityXmlService()
        {
            UrlSource = "allcity/?";
        }

        public QueryAllCityXmlService(IUnionConfig fig)
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
    public class HotelSearchXmlService : UnionDataUrlBase
    {
        public HotelSearchXmlService()
        {
            UrlSource = "hotel_list/?";
        }

        public HotelSearchXmlService(IUnionConfig fig)
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
    public class HotelSearchTipXmlService : UnionDataUrlBase
    {
        public HotelSearchTipXmlService()
        {
            UrlSource = "search.asp";
        }

        public HotelSearchTipXmlService(IUnionConfig fig)
            : base(fig)
        {
            UrlSource = "search.asp";
        }
    }

    #endregion
}