//首页用到
function GetVouchData(ur, city, updateid) {
    if (ur != null && ur != '' && ur != undefined) {
        if (city != null && city != undefined) {
            $.ajax(
            {
                type: 'Get',
                url: ur + '?city=' + encodeURI(city),
                data: null,
                timeout: 20000,
                beforeSend: function () {
                    //AjaxStart();
                },
                success: function (msg) {
                    $("#" + updateid).html(msg);
                    //这个地方，是在省页会用到的，在更新的时候，老是会显示出来
                    //AjaxStop();
                },
                complete: function () {
                    //AjaxStop();
                },
                error: function () {
                    //AjaxStop();
                }
            });
        }
        else {
            alert("提交的数据有点问题");
        }
    }
}

//首页，选出列出来的三个景区的不同价段的酒店
function GetLeftMidHotHotelInfo(ids, uri, updateId, min, max) {
    if (ids != null && ids != '' && ids != undefined && uri != null && uri != '' && uri != undefined) {
        $.ajax(
        {
            type: 'Get',
            url: uri + ids + '/' + min + '/' + max,
            data: null,
            timeout: 20000,
            beforeSend: function () {
                //AjaxStart();
            },
            success: function (msg) {
                $("#" + updateId).html(msg);
                //AjaxStop();
            },
            complete: function () {
                //AjaxStop();
            },
            error: function () {
                //AjaxStop();
            }
        });
    }
    else {
        alert("提交的数据有点问题");
    }
}


//详细页面用到的
//酒店信息,酒店评论,酒店图片,
function GetDetailMidHotelInfo(uri, par, updateid, classid) {
    if (uri != null && uri != '' && uri != undefined) {
        if (par != null && par != undefined) {
            $.ajax(
            {
                type: 'Get',
                url: uri + encodeURI(par),
                data: null,
                timeout: 20000,
                beforeSend: function () {
                    //AjaxStart();
                },
                success: function (msg) {
                    for (var i = 1; i < 5; i++) {
                        $('#menuId' + i).removeClass('tabcurrent');
                        if (i == classid) {
                            $('#menuId' + i).addClass('tabcurrent');
                        }
                    }
                    $("#" + updateid).html(msg);

                    //这个地方，是在省页会用到的，在更新的时候，老是会显示出来
                    //AjaxStop();
                },
                complete: function () {
                    //AjaxStop();
                },
                error: function () {
                    //AjaxStop();
                }
            });
        }
        else {
            alert("提交的数据有点问题");
        }
    }
}


//详细页面用到的
//更新我住过
function UpdateHotelLiveIn(uri, id, updateid) {
    if (uri != null && uri != '' && uri != undefined) {
        if (id != null && id != undefined) {
            $.ajax(
            {
                type: 'Get',
                url: uri + '?id=' + encodeURI(id),
                data: null,
                timeout: 20000,
                beforeSend: function () {
                    //AjaxStart();
                },
                success: function (msg) {
                    if (msg != null && msg != undefined) {
                        if (msg.success) {
                            $("#" + updateid).html(msg.livein);
                            alert('IPOW,感谢您的左键');
                        }
                        else {
                            alert('貌似服务器有点繁忙，麻烦您等一会儿吧！');
                        }
                    }
                    //AjaxStop();
                },
                complete: function () {
                    //AjaxStop();
                },
                error: function () {
                    //AjaxStop();
                }
            });
        }
        else {
            alert("提交的数据有点问题");
        }
    }
}


/*
* Compressed by iPow(www.iPow.cn)
下面的这几个,都是交通调用
*/
var userAgent = navigator.userAgent.toLowerCase(), is_opera = userAgent.indexOf("opera") != -1 && opera.version(), is_moz = (navigator.product == "Gecko") && userAgent.substr(userAgent.indexOf("firefox") + 8, 3), is_ie = (userAgent.indexOf("msie") != -1 && !is_opera) && userAgent.substr(userAgent.indexOf("msie") + 5, 3), iPowHotel = null;

function tabs(C, A, E) {
    var D = "#" + A, B = 0; $("#" + C + " ul li").click(function () {
        $("#" + C + " li").removeClass("tabcurrent"); B = $("#" + C + " ul li").index(this);
        $("#" + C + " li:eq(" + B + ")").attr("class", "tabcurrent"); B = parseInt(B + 1);
        $(D + " .tabcontainerhide").attr("class", "tabcontainerhide");
        $(D + " .tabcontainershow").attr("class", "tabcontainerhide");
        $(D + B).attr("class", "tabcontainershow"); return false
    }).filter(":first").click()
}

function loadingHtml(obj1, obj2) {
    var html = jQuery("#" + obj2).html();
    jQuery("#" + obj1).html(html);
    if (obj2 == 'cirSightIDs') {
        var list = mapDataProcess(sightMap);
        HotelMarker.resetMarkers(map, list);
        HotelMarker.setCenterAndZoom(map, list);
    }
    if (obj2 == 'cirHotelIDs') {
        var list = mapDataProcess(hotelMap);
        HotelMarker.resetMarkers(map, list);
        HotelMarker.setCenterAndZoom(map, list);
    }
}

function tabsDisplay(E, A) {
    var B = "#" + A, C, D = 0; $("#" + E + " ul li").click(function () {
        $.each([1, 2, 3], function (A, B) { $("#" + E + " ul li:eq(" + A + ")").attr("class", "style" + B + "_2") });
        $(".trafficSearch .trafficSearchMid").hide(); D = $("#" + E + " ul li").index(this);
        D = parseInt(D + 1); $(this).attr("class", "style" + D + ""); C = B + "0" + D;
        $(C).show(); return false
    }).filter(":first").click()
}
