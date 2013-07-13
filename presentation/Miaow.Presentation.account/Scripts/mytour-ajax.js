var clickValue = 0;
var clickMapValue = 0;
var ShareHtml = "";
var StrAmbitusHtml = "";
var clickPathValue = 0;

//change 是this   ParkID Name
function addSight(id, ParkID, PlanID, Days) {




    document.getElementById("getAmbitus").style.display = "none";
    var obj = {
        ParkID: ParkID,
        PlanID: PlanID,
        Days: Days
    };
    //去toutPlanDeail Select 此ID是否已经添加了
    var dta = {
        ParkID: ParkID,
        PlanID: PlanID
    };
    $.ajax({
        Type: "GET",
        url: "/mytour/home/checkaddsightbyid",
        data: dta,
        dataType: "text",
        success: function (data) {
            if (data != "1") {
                if ($("#" + id).css('backgroundColor') == "red") {
                    return false;
                }
                else {
                    $("#" + id).css("background-color", "red");
                    $.ajax({
                        Type: "GET",
                        url: "/mytour/home/clickaddsight",
                        data: obj,
                        dataType: "json",
                        success: function (data) {
                            if (data != null) {
                                clickValue = clickValue + 1;
                                var ParkID = data.ParkID;
                                ShowClickLable(data, clickValue, PlanID);
                                initializeMap(data, clickValue);
                            }
                            else {
                                alert("不合法未能添加成功!");
                            }
                        }
                    });
                }
            }
            else {
                //不可重复添加 
            }
        }
    });
}


function ShowClickLable(data, clickValue, PlanID) {
    for (var i = 1; i < clickValue; i++) {
    }
    ShareHtml += "<div  id=" + "sight_" + data.ParkID + "  class=\"getPointsDiv\"  style=\"height: 110px;width: 450px;z-index:-1\" onclick=\"ClickShowMap(this.id," + PlanID + ")\">";
    ShareHtml += "<div style=\"height: 25px;width: 450px;\"><div style=\"height: 20px;width: 20px;background-color:#008000;text-align:center\" >" + i + "</div><a style=\"color:blue\">点击可在最下方显示地图</a></div>";
    ShareHtml += "<ul> ";
    ShareHtml += "<li ><a id=" + "titile_" + data.ParkID + "   style=\"height: 15px;width: 400px;text-decoration: none\" > " + data.Title + "</a></li><br/>";
    ShareHtml += "<li><ul>";
    ShareHtml += "<li>" + data.Ticket + "元/人" + " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li>";
    if (data.GoCount == 0) {
        ShareHtml += "<li><a style=\"text-decoration: none\" >还木有人去过！</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li></ul><br/>";
    }
    else {
        ShareHtml += "<li><a style=\"text-decoration: none\">" + data.GoCount + "人去过" + "</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li></ul><br/>";
    }

    //  ShareHtml += " <a  style=\"z-index:1\"  href=\"javascript:void()\" onclick=\" updatesightbyid(" + PlanID + "," + "sight_" + data.ParkID + ")\"  > <img  title=\"点击修改\" src=\"/images/icn_edit.png\" ><br/>";  
    // ShareHtml += "<a  style=\"z-index:1\"  href=\"javascript:void()\" onclick=\"deletesightbyid(" + PlanID + "," + "sight_" + data.ParkID + ")\" ><img title=\"点击删除\" src=\"/images/icn_trash.png\" ></a>";       
    //  ShareHtml += "<li  id=\"Coords\"><a>" + data.CirParkID + "</a></li>";

    ShareHtml += "</ul>";
    ShareHtml += "</div><br/>";
    document.getElementById("showClickSight").innerHTML = ShareHtml;
}

//baidu MAP
//click景点标示 然后获得 经纬 在去 百度拿地图
function ClickShowMap(id, PlanID) {
    var Id = id.substring(6);
    var obj = {
        Id: Id
    };
    if (Id = null) {
        return false;
    }
    else {
        $.ajax({
            Type: "GET",
            url: "/mytour/home/getsightlonandlat",
            data: obj,
            dataType: "json",
            success: function (data) {
                clickMapValue = clickMapValue + 1;
                MapLoading(data, clickMapValue, PlanID);  //这里是sight
            }
        });
    }
}

//添加多个地图标注  首先是将目的地Destination 为标注 point
//Destination 为AddSight()传过来的目的地 为map的标注
function initializeMap(data, clickValue) {
    var obj =
        {
            Destination: data.City
        };
    if (clickValue > 1) {
        return false;
    }
    else {
        $.ajax({
            Type: "GET",
            url: "/mytour/home/getsightdestinationlonandlat",
            data: obj,
            dataType: "json",
            success: function (data) {
                var lon = data.Longitude;
                var lat = data.Latitude;
                var map = new BMap.Map("container");
                var pointMarker = new BMap.Point(lon, lat);
                map.centerAndZoom(pointMarker, 12);
                window.map = map; //将map变量存储在全局
                var marker1 = new BMap.Marker(pointMarker); // 创建标注 
                map.addOverlay(marker1); // 将标注添加到地图中 
                marker1.setTitle(data.City); //标注 鼠标移入的文本
                var label = new BMap.Label(data.City, { point: pointMarker, offset: new BMap.Size(1, +6) });       //定义一个文字标签
                map.addOverlay(label);   //将文本添加在map中
            }
        });
    }
}

//向地图中添加了 1,2.3,4,5,6,7,N个景点
// PlanID DIY线路的 ID 
function MapLoading(data, clickMapValue, PlanID) {
    document.getElementById("container").style.display = "";
    for (var i = 0; i < clickMapValue; i++) {
        var lon = data.Longitude;
        var lat = data.Latitude;
        var myIcon = new BMap.Icon("http://dev.baidu.com/wiki/static/map/API/examples/images/ico-1-9.png", new BMap.Size(28, 37),
          {
              offset: new BMap.Size(10, 25),
              imageOffset: new BMap.Size(1 - i * 28, 0)
          });
        var polyline = new BMap.Polyline([
        new BMap.Point(lon, lat),
        new BMap.Point(map.defaultCenter.lng, map.defaultCenter.lat)],
        { strokeColor: "green", strokeWeight: 5, strokeOpacity: 0.5 });
        map.addOverlay(polyline);
        var i = new BMap.Point(lon, lat);
        setMapEvent();
        var marker = new BMap.Marker(i, { icon: myIcon })  //将自定义的图标标注在标注中
        map.addOverlay(marker); // 将标注添加到地图中 
        marker.setTitle(data.Title);
        //marker.setAnimation(BMAP_ANIMATION_BOUNCE); //跳动的动画 
        //调用信息窗口

        if (data.Remark.length > 33) {
            var Remark = data.Remark.substring(0, 33) + "...";
        }
        var infoWindow = new BMap.InfoWindow("<a  id='title' style='font-size: 12px;color:#069'>" + data.Title + "</a><br/><a style='font-size: 12px;'> " + data.VoIndex + "(" + data.CommCount + "条评论)" + "</a><br/><a  id='address' style='font-size: 12px;'>" + "地址:" + data.Address + "</a><br/><a style='font-size: 12px;'>" + "电话:" + data.Telephone + "</a><br/><a style='font-size: 12px;'>" + "票价:" + data.Ticket + "/元" + "</a><br/><a style='font-size: 12px;'>" + "介绍:<br/>" + Remark + "</a><br/><a href=" + data.Url + ">更多详情</a><br/><img src=" + "http://www.img1.ipow.cn" + data.PicPath + "><br/><a id='Path' href='javascript:void(0)' onclick='GetPathDIV(" + PlanID + ")'>公交查询</a>&nbsp;&nbsp;&nbsp;&nbsp;<a id=' Ambitus' href='javascript:void(0)' onclick=' GetAmbitusDIV(" + data.ParkID + ") ' >周边搜索</a><br/>");
        map.openInfoWindow(infoWindow, map.getCenter());
        marker.addEventListener("click", function () {
            this.openInfoWindow(infoWindow);
        });
    }
}

//地图事件设置函数：
function setMapEvent() {
    map.enableDragging(); //启用地图拖拽事件，默认启用(可不写)
    //  map.enableScrollWheelZoom(); //启用地图滚轮放大缩小
    map.enableDoubleClickZoom(); //启用鼠标双击放大，默认启用(可不写)
    map.enableKeyboard(); //启用键盘上下左右键移动地图
    map.addControl(new BMap.NavigationControl());    // 获取鱼骨缩放
    map.addControl(new BMap.ScaleControl()); //比例尺控件
}

//删除 DIYSight
function deletesightbyid(id, ParkID) {
    alert("触发");
    var obj = {
        id: id
    };
    $.ajax({
        url: "/mytour/home/deletesightdiy",
        Type: "GET",
        data: obj,
        datatype: "text",
        success: function (data) {
            if (data != "1") {
                alert("抱歉删除出错！请联系管理员");
            }
            else {
                //表示成功  那么上方块儿里的 信息就得干掉                  
                strHtml = "";
                ParkID.innerHTML = strHtml;
            }
        }
    });
}

//上面的关键字查询
function checkValue() {
    document.getElementById("keywords").innerHTML = "";
    var city = document.getElementById("city").value;
    if (city != "") {
        var local = new BMap.LocalSearch(map, {
            renderOptions: { map: map, panel: "keywords" }
        });
        local.search(city);
        return true;
    }
    else {
        return false;
    }
}

//公交查询
//传入的ID是 用户DIY的IT  该ID下包含了用户添加的所有的景点 
function GetPathDIV(id) {
    document.getElementById("pathlablediv").style.display = "";
    var obj = {
        id: id
    };
    $.ajax({
        Type: "GET",
        url: "/mytour/home/getuserdiytourbyid",
        dataType: "json",
        data: obj,
        success: function (data) {
            //调用生成Title的 标签
            CreatePathTitle(data);
        },
        error: function () {
            alert("data is null && is error in function GetPathDIV()");
        }
    });
}

//公交查询
//生成Title的 标签
function CreatePathTitle(data) {
    var PlusHtml = "";
    document.getElementById("origin").innerHTML = "";
    document.getElementById("finish").innerHTML = "";
    if (data != null) {
        $.map(data.List, function (ipow) {
            PlusHtml += "<option   id=" + ipow.ParkID + " value=" + ipow.InSource + ">" + ipow.InSource + "</option>";
        });
        document.getElementById("origin").innerHTML = PlusHtml;  //起点
        document.getElementById("finish").innerHTML = PlusHtml;   //终点
    }
    else {
        alert(" Error：公交查询标签信息生成失败");
    }
}

//得到 【起 / 始】交通路线 
function SearchTransit() {
    document.getElementById("keywords").innerHTML = "";
    var origin = document.getElementById("origin").value       //= $("#origin").val();  
    var finish = document.getElementById("finish").value         //= $("#finish").val();
    if (origin == finish || origin == "" || finish == "") {
        alert("起始地相同或为空！");
        return false;
    }
    else {
        var transit = new BMap.TransitRoute(map, {                        //结果在  ID="label"  PathDIV
            renderOptions: { map: map, panel: "keywords" }
        });
        transit.search(origin, finish);
        return true;
    }
}


//显示周边搜索的标签
//  id=data.ParkID 
function GetAmbitusDIV(id) {
    document.getElementById("getAmbitus").style.display = ""; //显示
    document.getElementById("search_sight").id = id;  //周边景点  改变它的ID为 当前景点ID  
    document.getElementById("search_stay").id = id;   //周边旅店
}

//周边景点搜索  非家数据
// id is SeachType
// address 确定是哪一个景区的地址 用来确定地点来搜周边
//function SearchAmbitus(id) {
//    var type = document.getElementById(id).innerHTML;
//    var address = document.getElementById("address").innerHTML;
//    var local = new BMap.LocalSearch(map, {
//        renderOptions: { map: map, autoViewport: true }
//    });
//    local.searchNearby(type, address);
//}

//自家数据+获得周边景点  By SightID   SearchAmbitus(id)
function SearchSight(PlanID) {  //GetCirSightInfo
    var obj = {
        Id: PlanID
    };
    $.ajax({
        Type: "GET",
        url: "/mytour/home/getcirsightinfobyid",
        dataType: "json",
        data: obj,
        success: function (data) {
            AmbitusSightShow(data, PlanID);     //调用 自家数据显示在Map中  函数
        }
    });
}

//自家数据显示在Map中  sight
function AmbitusSightShow(data, PlanID) {
    if (data != null) {
        $.map(data.List, function (sight) {
            var lon = sight.Longitude;
            var lat = sight.Latitude;
            var a = new BMap.Point(lon, lat);
            var marker = new BMap.Marker(a)
            map.addOverlay(marker);
            marker.setTitle(sight.Title);
            //信息窗口
            if (sight.Remark.length > 33) {
                var Remark = sight.Remark.substring(0, 33) + "...";
            }
            var infoWindow = new BMap.InfoWindow("<a  id='title' style='font-size: 12px;color:#069'>" + sight.Title + "</a><br/><a style='font-size: 12px;'> " + sight.VoIndex + "(" + sight.CommCount + "条评论)" + "</a><br/><a  id='address' style='font-size: 12px;'>" + "地址:" + sight.Address + "</a><br/><a style='font-size: 12px;'>" + "电话:" + sight.Telephone + "</a><br/><a style='font-size: 12px;'>" + "票价:" + sight.Ticket + "/元" + "</a><br/><a style='font-size: 12px;'>" + "介绍:<br/>" + Remark + "</a><br/><a href=" + sight.Url + ">更多详情</a><br/><img src=" + "http://www.img1.ipow.cn" + sight.PicPath + "><br/>");
            //<a id='Path' href='javascript:void(0)' onclick='GetPathDIV(" + PlanID + ")'>公交查询</a>&nbsp;&nbsp;&nbsp;&nbsp;<a id=' Ambitus' href='javascript:void(0)' onclick=' GetAmbitusDIV(" + sight.ParkID + ") ' >周边搜索</a><br/>
            map.openInfoWindow(infoWindow, map.getCenter());
            marker.addEventListener("click", function () {
                this.openInfoWindow(infoWindow);
            });
        });
    }
}

//获得周边 HotalInfo By SightID
function SearchHotel(PlanID) {
    var obj = {
        Id: PlanID
    };
    $.ajax({
        Type: "GET",
        url: "/mytour/home/gethotelinfobyid",
        dataType: "json",
        data: obj,
        success: function (data) {
            AmbitusHotelShow(data, PlanID)
        },
        error: function () {
            alert("获得周边酒店失败!");
        }
    });
}

/// 数据不是很多很全 所以未被调用
///自家数据显示在Map中 hotel
function AmbitusHotelShow(data, PlanID) {
    if (data != null) {
        $.map(data.List, function (sight) {
            var lon = sight.Longitude;
            var lat = sight.Latitude;
            var a = new BMap.Point(lon, lat);
            var marker = new BMap.Marker(a)
            map.addOverlay(marker);
            marker.setTitle(sight.Title); //标注 鼠标移入的文本
            //信息窗口
        });
    }
}




