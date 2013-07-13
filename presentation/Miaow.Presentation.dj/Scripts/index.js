/// <reference path="jquery-1.4.4-vsdoc.js" />
$(document).ready(function () {
    var upAdBanner = function () {
        $(".adtop").slideUp(800);
    };
    //广告下拉  
    $(".adtop").slideDown(800);
    //设置延迟的广告收回，这里是8秒  
    setTimeout(upAdBanner, 8000);
});
$(function () {
    $("#ulListSight li").mouseover(function () {
        this.className = "tottbg";
    });
    $("#ulListSight li").mouseout(function () {
        $(this).removeClass("tottbg");
    });
});

function GetTopTourCity(name, cursel, n, city) {
    for (i = 1; i <= n; i++) {
        var menu = $("#" + name + i);
        if (i == cursel) {
            menu.removeClass();
            menu.addClass("cityxu");
        }
        else {
            menu.removeClass();
        }
    }
    ajaxFunction('POST', '/home/toptourplancity/' + encodeURI(city), '', 20000, 'divTopTrou')
}

function ajaxFunction(ty, ur, dat, time, upId) {
    $.ajax(
    {
        type: ty,
        url: ur,
        data: dat,
        timeout: time,
        dataType: "html",
        cache: false,
        beforeSend: function () {
            AjaxStart();
        },
        success: function (msg) {
            $("#" + upId).html(msg);
            AjaxStop();
        },
        complete: function () {
            AjaxStop();
        },
        error: function () {
            AjaxStop();
        }
    });
}

function AjaxStart() {
    //   $.blockUI({ message: '<img  src="@Url.Content("~/Content/Images/loading4.gif")" width="16"  height="16"/><font color="#2E6092" size="2">正在加载，稍候更精彩...</font>' });
}
function AjaxStop() {
    // $.unblockUI();
}
$(function () {
    $(".imgLeft").colorbox({
        rel: 'imgLeft',
        slideshow: false,
    });
})