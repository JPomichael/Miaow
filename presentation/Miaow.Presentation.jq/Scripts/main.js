/*
*  Copyright (c) 2010 iPow(www.iPow.cn)
*/


function updateSightInfo(ur, upId) {
    $.ajax(
    {
        type: 'POST',
        url: ur,
        data: null,
        timeout:20000,
        beforeSend: function () {
            AjaxStart();
        },
        success: function (msg) {
            $("#" + upId).html(msg);
            //这个地方，是在省页会用到的，在更新的时候，老是会显示出来
            var addDispaly = $("#addrProvince").css("display");
            if (addDispaly != undefined) {
                $("#addrProvince").css("display", "none");
            }
            AjaxStop();
        },
        complete: function () {
            AjaxStop();
        },
        error: function () {
            AjaxStop();
        }
    }
       );
}

jQuery.fn.showCity = function (A) {
    A = jQuery.extend({ title: "", data: "" }, A);
    return this.each(function () {
        var C = this, A = getAllPosition(C), B = function () { var A = ""; $("#divCity").show() };
        $(C).unbind().hover(function () { B(); }, function () { $("#divCity").hide() })
    })
};
function getAllPosition(C) {
    var A = [], D = $(C).offset(); A.offLeft = D.left; A.offTop = D.top; A.offWidth = document.documentElement.clientWidth; A.offHeight = document.documentElement.clientHeight; var B; if (typeof window.pageYOffset != "undefined") B = window.pageYOffset; else if (typeof document.compatMode != "undefined" && document.compatMode != "BackCompat") B = document.documentElement.scrollTop; else if (typeof document.body != "undefined") B = document.body.scrollTop; A.scrTop = B; return A
} jQuery.extend(jQuery.easing, { easeInOutExpo: function (E, B, C, D, A) { if (B == 0) return C; if (B == A) return C + D; if ((B /= A / 2) < 1) return D / 2 * Math.pow(2, 10 * (B - 1)) + C; return D / 2 * (-Math.pow(2, -10 * --B) + 2) + C }, easeInSine: function (E, B, C, D, A) { return -D * Math.cos(B / A * (Math.PI / 2)) + D + C }, easeInCirc: function (E, B, C, D, A) { return -D * (Math.sqrt(1 - (B /= A) * B) - 1) + C } });
$.fn.floatDiv = function (A) {
    A = $.extend({}, A);
    return this.each(function () {
        var C = this;
        function B() {
            $("#maproll").unbind().click(function () {
                var B = $(this).attr("checked");
                if (B) A(); else {
                    $(window).unbind("scroll");
                    $(C).animate({ top: 0 }, 500, "easeInSine")
                }
            });
            A()
        }
        function A() {
            var A = $(document).scrollTop(); $(C).css("position", "relative");
            $(C).scrollFollow()
        } B()
    })
};
$.fn.scrollFollow = function (A) {
    A = $.extend({
        relativeTo: "top", speed: 500, offset: 0, easing: "easeInSine", container: this.parent().attr("id"), killSwitch: "killSwitch", onText: "Turn Slide Off", offText: "Turn Slide On", delay: 0
    }, A); return this.each(function () {
        var D = $(this);
        function C() {
            D.queue([]); var F = parseInt($(window).height()), C = parseInt($(document).scrollTop()), I = parseInt(D.cont.offset().top), E = parseInt(D.cont.attr("offsetHeight")), H = parseInt(D.attr("offsetHeight") + (parseInt(D.css("marginTop")) || 0) + (parseInt(D.css("marginBottom")) || 0)), G;
            if (B) { if (A.relativeTo == "top") { if (D.initialOffsetTop >= (C + A.offset)) G = D.initialTop; else G = Math.min((Math.max((-I), (C - D.initialOffsetTop + D.initialTop)) + A.offset), (E - H - D.paddingAdjustment)) } else if (A.relativeTo == "bottom") if ((D.initialOffsetTop + H) >= (C + A.offset + F)) G = D.initialTop; else G = Math.min((C + F - H - A.offset), (E - H)); if ((new Date().getTime() - D.lastScroll) >= (A.delay - 20)) D.animate({ top: G }, A.speed, A.easing) }
        } var B = true;
        if ($.cookie != undefined) if ($.cookie("scrollFollowSetting" + D.attr("id")) == "false") {
            B = false; $("#" + A.killSwitch).text(A.offText).toggle(function () {
                B = true; $(this).text(A.onText);
                $.cookie("scrollFollowSetting" + D.attr("id"), true, { expires: 365, path: "/" }); C()
            }, function () {
                B = false; $(this).text(A.offText); D.animate({ top: D.initialTop }, A.speed, A.easing); 
                $.cookie("scrollFollowSetting" + D.attr("id"), false, { expires: 365, path: "/" })
            })
        } else $("#" + A.killSwitch).text(A.onText).toggle(function () {
            B = false;
            $(this).text(A.offText); D.animate({ top: D.initialTop }, 0);
            $.cookie("scrollFollowSetting" + D.attr("id"), false, { expires: 365, path: "/" })
        },
         function () {
             B = true; $(this).text(A.onText); $.cookie("scrollFollowSetting" + D.attr("id"), true, {
                 expires: 365, path: "/"
             }); C()
         }); if (A.container == "") D.cont = D.parent();
        else D.cont = $("#" + A.container); D.initialOffsetTop = parseInt(D.offset().top);
        D.initialTop = parseInt(D.css("top")) || 0;
        if (D.css("position") == "relative") D.paddingAdjustment = parseInt(D.cont.css("paddingTop")) + parseInt(D.cont.css("paddingBottom"));
        else D.paddingAdjustment = 0;
        $(window).scroll(function () {
            $.fn.scrollFollow.interval = setTimeout(function () { C() }, A.delay);
            D.lastScroll = new Date().getTime()
        });
        $(window).resize(function () {
            $.fn.scrollFollow.interval = setTimeout(function () { C() }, A.delay);
            D.lastScroll = new Date().getTime()
        });
        D.lastScroll = 0; C()
    })
}