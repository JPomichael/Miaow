/*
* Compressed by iPow(www.iPow.cn)
*/
var userAgent = navigator.userAgent.toLowerCase(), is_opera = userAgent.indexOf("opera") != -1 && opera.version(), is_moz = (navigator.product == "Gecko") && userAgent.substr(userAgent.indexOf("firefox") + 8, 3), is_ie = (userAgent.indexOf("msie") != -1 && !is_opera) && userAgent.substr(userAgent.indexOf("msie") + 5, 3), iPowComm;

function GetSightData(sid, tarId) {
    var data = 0;
    if (tarId != "" && sid != "") {
        var url = "/";
        switch (tarId) {
            case "GoCount":
                url += "GoCount/" + sid.toString() + "/1";
                break;
            case "WantCount":
                url += "WantGo/" + sid.toString() + "/1";
                break;
            default:
                break;
        }
        $.getJSON(url, null, function (data) {
            if (data.success != "false") {
                $("#" + tarId).html(data.count);
            }
        });
    }
}

function showCommReply(B, A) {
    $("#txtReContent").attr("value", "");
    $("#commReply a").unbind("click");
    $("#commReply a").click(
  function () { replyComm(A, B) });
    if (iPowComm != null) iPowComm.showCommReply(B, A)
}
function replyComm(A, B)
{ if (iPowComm != null) iPowComm.replyComm(A, B) }
function getCommList(B, A, C) { if (iPowComm != null) iPowComm.getCommList(B, A, C) }
function addCommInfo(A) { if (iPowComm != null) iPowComm.addCommInfo(A) }
function statInfo(C, B, A) { if (iPowComm != null) iPowComm.statInfo(C, B, A) }
function showPicList(A, E, C, D, B) { if (iPowComm != null) iPowComm.showPicList(A, E, C, D, B) }
function showArticleList(A, D, B, C) { if (iPowComm != null) iPowComm.showArticleList(A, D, B, C) }
function rightTab(E, C, D, B) {
    var A;
    $("#" + E + " a").click(function () {
        $("#" + E + " a").attr("class", "" + D + "");
        $(" ." + C + "").attr("class", "" + C + "Hide");
        A = $("#" + E + " a").index(this);
        A = parseInt(A + 1);
        $("#" + C + "" + A + "").attr("class", "" + C + "");
        $("#" + this.id).attr("class", "" + B + "")
    })
}
function leftTab(E, B, D, C) {
    var A;
    $("#" + E + " a").click(function () {
        $("#" + E + " a").attr("class", "" + D + "");
        $("#" + B + " div").attr("class", "cirListHide");
        A = $("#" + E + " a").index(this);
        A = parseInt(A + 1);
        $("#" + B + "" + A + "").attr("class", "infoContainer");
        $("#" + this.id).attr("class", "" + C + "")
    })
}
function changeCss(A, B) {
    $("#" + A + " a").attr("class", "" + B + "")
}
function loadHtml(A, B) {
    $("#" + A).load("" + B + "")
}
function ajaxLoadInfo(G, E, C, F, A, D) {
    showLoading(F);
    if (isUndefined(E)) E = "";
    if (isUndefined(D)) D = "";
    if (isUndefined(C)) C = "";
    if (isUndefined(A)) A = "";
    switch (C) {
        case "href":
            var B = !isUndefined($("#" + E).attr("href")) ? $("#" + E).attr("href") : $("#" + E).attr("href"); loadHtml(F, B);
            break;
        case "url": B = E; loadHtml(F, B);
            break; default: break
    }
    doane(G)
}
function doane(A) {
    e = A ? A : window.event; if (is_ie) { e.returnValue = false; e.cancelBubble = true } else if (e) { e.stopPropagation(); e.preventDefault() }
} function isUndefined(A)
{ return typeof A == "undefined" ? true : false }
function showLoading(A, B) {
    var B = B ? B : "Loading..."; $("#" + A).html(B)
}
function showStart(B, A) {
    $("#" + A).show()
}
jQuery.fn.extend({
    Star: function (A) {
        A = $.extend({ on: "", off: "", enable: false }, A); return this.each(function () { var C = $(this), D = $.ToInt(C.attr("val") / 1), B = 0; while (B < D) { C.append("<img src='" + A.on + "' alt='" + (B + 1) * 1 + "' val='" + (B + 1) * 1 + "' align='absmiddle'/>"); B++ } while (B < 5) { C.append("<img src='" + A.off + "'  alt='" + (B + 1) * 1 + "'  val='" + (B + 1) * 1 + "' align='absmiddle'/>"); B++ } if (A.enable) { var E = C.children(); E.mouseover(function () { var B = 0; while (B < $.ToInt($(this).attr("val") / 1)) { E[B].src = A.on; B++ } while (B < 5) { E[B].src = A.off; B++ } }); E.mouseout(function () { var B = 0; while (B < D) { E[B].src = A.on; B++ } while (B < 5) { E[B].src = A.off; B++ } }); E.click(function () { var A = $(this).attr("val"); D = $.ToInt(A / 1); C.attr("val", A); doVouch(A); C.hide() }) } })
    }
});
function TransportsTab(B, A) {
    $("#Transport" + B).show();
    $("#Transport" + A).hide();
    $("#TransportTab" + B).attr("class", "current");
    $("#TransportTab" + A).removeClass("current")
}