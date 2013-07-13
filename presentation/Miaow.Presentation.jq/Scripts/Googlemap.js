
//
var googleMap;

var gdir;

var geocoder = null;

var addressMarker;

var centerRoute = "";

function initialize(mylat, mylong, title) {
    if (GBrowserIsCompatible()) {
        //位置
        googleMap = new GMap2(document.getElementById("map_right"));
        var center = new GLatLng(mylat, mylong);

        centerRoute = mylat + "," + mylong;

        googleMap.setCenter(center, 13);
        //查询结果
        gdir = new GDirections(googleMap, document.getElementById('sHowList'));
        GEvent.addListener(gdir, "error", handleErrors);
        geocoder = new GClientGeocoder();

        //定义一些控件
        var customUI = googleMap.getDefaultUI();
        customUI.maptypes.hybrid = false;
        customUI.maptypes.physical = false;


        googleMap.addControl(new GLargeMapControl());
        googleMap.setUI(customUI);
        //          map.disableDoubleClickZoom();
        //   	map.enableContinuousZoom();
        var ovcontrol = new GOverviewMapControl(new GSize(100, 100));
        googleMap.addControl(ovcontrol);

        //因为后面要重新定义双击事件，这里移除双击放大事件
        var marker = new GMarker(center);
        GEvent.addListener(marker, "click", function () {
            marker.openInfoWindowHtml("<p style=\"font-size:12px;font-family:'宋体'; margin-top:0px;color:#D21718;font-weight:bold;\">" + title + "欢迎您！</p>");
            marker.openInfoWindowHtml("<p style=\"font-size:12px;font-family:'宋体'; margin-top:0px;color:#D21718;font-weight:bold;\">" + title + "欢迎您！</p>");

        });
        googleMap.addOverlay(marker);
        GEvent.addListener(googleMap, "dblclick", function (overlay, latlng) {
            //getLocations方法反向地址解析，即坐标解析为中文地址
            //返回类型为json
            geocoder.getLocations(latlng, function (data) {
                addressMarker = new GMarker(latlng);
                var latRoute = String(latlng.lat());
                var lngRoute = String(latlng.lng());
                var addressName = cutAddress(data.Placemark[0].address);
                var myhtml = addressName + "<br /><a class='google_link' style='cursor:pointer;color:#0000CC;font-size:13px;' onclick='dblclickLoad(\"" + addressName + "\",\"" + latRoute + "\",\"" + lngRoute + "," + title + "\");'>从此处前往" + title + "欢迎您</a>";
                googleMap.openInfoWindowHtml(latlng, myhtml);
            });
        });
    }
}


//设置区域限制
function setAddressLimit(address) {
    //      if (address.indexOf("北京") == -1)
    //      {
    //          address = "北京 "+address;
    //      }
    return address;
}
//去掉返回地址的前缀
function cutAddress(address) {
    if (address.indexOf("中华人民共和国北京") != -1) {
        address = address.replace(/中华人民共和国北京/, "");
    }
    return address;
}
//从地图任意点到终点
function dblclickLoad(name, latRoute, lngRoute, title) {
    var routeStr = "from: <font color='black'>" + name + "</font>@" + latRoute + "," + lngRoute + " to: " + title + "@" + centerRoute;
    gdir.load(routeStr, { travelMode: G_TRAVEL_MODE_DRIVING });
}

//乘车路线
function luxian(sourceAddress) {
    //这个可以调背景色的
    $("div[jstcache=8]").attr("style", "color:red;");
    var fromAddress = document.getElementById('startName_driver');
    var toAddress = document.getElementById('endName_driver');
    var address = fromAddress.value;
    if (fromAddress.value == "" || fromAddress.value == "请输入起点!") {
        alert("请输入您的出发的起点吧^_^!");
        return false;
    }

    //这个地方啊，加载数据之后，那个样式会变，所以就改变一下样式了
    $("#sHowList").html("");
    $("#sHowList").css("width", "225px");
    $("#sHowList").css("height", "315px");

    document.getElementById('sHowList').innerText = "";
    //getLocations方法解析地址，返回json
    geocoder.getLocations(setAddressLimit(address),
          function (json) {
              if (!json) {
                  alert("解析\"" + address + "\"错误");
              }
              else {

                  //地址解析为坐标可能有多个结果，这里只取查询结果的第一个json.Placemark[0]
                  //有兴趣扩展可以通过遍历json输出所有查询结果，让使用者选择最符合的结果。
                  var addressRoute = "from:" + address + "@" + json.Placemark[0].Point.coordinates[1]
                      + "," + json.Placemark[0].Point.coordinates[0]
                      + " to: " + sourceAddress + "@" + centerRoute;

                  //设置路线起始点坐标
                  gdir.load(addressRoute, { travelMode: G_TRAVEL_MODE_DRIVING }); //驾车
                  // G_TRAVEL_MODE_WALKING//步行
              }
          });

    /*
    //getLatLng方法
    geocoder.getLatLng(setAddressLimit(address),
    function(point)
    {
    if (!point)
    {
    alert("解析\""+address+"\"错误");
    }
    else
    {
    var addressRoute = "from: "+address+"@"+point.lat()+","+point.lng()+" to: 金福楼@"+centerRoute;
    gdir.load(addressRoute,{travelMode:G_TRAVEL_MODE_DRIVING});
    }
    });
          
    //jquery的getJSON方法http请求解析,用此方法需引入jquery框架
    $.getJSON("http://maps.google.com/maps/geo?q="+encodeURIComponent(setAddressLimit(address))+"&output=json&key=ABQIAAAAQ0pgyic4ROE9rr4PWF1qBRDvuDKJLLEMBt0175lffxKd2WRRBRIVZEREjaUWbrLdbvDieibc2PHlg&callback=?",
    function(data,textStatus)
    {
    var latlng=data.Placemark[0].Point.coordinates[1]+","+data.Placemark[0].Point.coordinates[0];
    gdir.load("from: "+address+"@"+latlng+" to: 金福楼@"+centerRoute,{travelMode:G_TRAVEL_MODE_DRIVING})
    });
    */
}
function handleErrors() {
    if (gdir.getStatus().code == G_GEO_UNKNOWN_ADDRESS)
        alert("没有相应的地理位置无法获得一个指定的地址。这可能是由于这样的事实:地址是相对较新的,或它可能是错误的。\ nError代码: " + gdir.getStatus().code);
    else if (gdir.getStatus().code == G_GEO_SERVER_ERROR)
        alert("一个地理编码或指令的要求并无法成功地处理,然而失败的确切原因尚不清楚。\ n错误代码: " + gdir.getStatus().code);
    else if (gdir.getStatus().code == G_GEO_MISSING_QUERY)
        alert("HTTP问参数或者被丢失或毫无价值。为在要求,这意味着一个空的地址是指定的作为输入。为我指路的要求,这意味着任何查询被指定在输入。\ n错误代码: " + gdir.getStatus().code);
    else if (gdir.getStatus().code == G_GEO_BAD_KEY)
        alert("给定的关键不是无效或不符合域值,并对它进行了必要的分析说明。\ n错误代码: " + gdir.getStatus().code);
    else if (gdir.getStatus().code == G_GEO_BAD_REQUEST)
        alert("一个方向的要求并无法成功地解析。\ n错误代码: " + gdir.getStatus().code);
    else alert("一个未知的错误发生！");
}

function onGDirectionsLoad() {
    // Use this function to access information about the latest load()
    // results.

    // e.g.
    // document.getElementById("getStatus").innerHTML = gdir.getStatus().code;
    // and yada yada yada...
}