/*
* Compressed by iPow(www.iPow.cn)
*/
function c$(B, A) {
    var C = document.getElementById(B); if (!C) {
        GetPyzyIframe("ifm" + B); C = document.createElement("div"); C.id = B; if (A && A != "") C.className = A;
        document.body.appendChild(C)
    } return C
} function GetPyzyIframe(E, D, F, C, A, G) {
    var B = document.getElementById(E);
    if (!B) {
        B = document.createElement("iframe");
        B.id = E; B.style.position = "absolute";
        B.style.zIndex = "1";
        B.style.visibility = "hidden"; document.body.appendChild(B)
    }
    if (F) B.style.top = F + "px";
    if (C) B.style.left = C + "px"; if (A) B.style.width = A + "px";
    if (G) B.style.height = G + "px";
    if (D) B.style.visibility = (document.all ? D : "hidden");
    return B
}
function getPosition(C) {
    var B = 0, E = 0, A = C.offsetWidth, D = C.offsetHeight;
    while (C.offsetParent) { B += C.offsetTop; E += C.offsetLeft; C = C.offsetParent }
    return { "top": B, "left": E, "width": A, "height": D }
}
function GetValueToInputObj(B) {
    if (!B) return null;
    var A = (B.getAttributeNode("value_to_input") ? B.getAttributeNode("value_to_input").value : "");
    if (A == "")
        return null;
    return document.getElementById(A)
}
function AutoNextInputAct(fctThisObj, fctAct) {
    var varNextInput = fctThisObj.getAttributeNode("nextinput");
    if (varNextInput && varNextInput != "") {
        if (document.all) eval("document.getElementById('" + varNextInput.value + "')." + fctAct + "()");
        else {
            var evt = document.createEvent("MouseEvents"); evt.initEvent(fctAct, true, true);
            document.getElementById(varNextInput.value).dispatchEvent(evt)
        }
        document.getElementById(varNextInput.value).focus()
    }
}
function AddFunToObj(fctObj, fctAct, fctFunction) {
    if (fctObj.addEventListener) fctObj.addEventListener(fctAct.replace("on", ""),
         function (e) { e.cancelBubble = !eval(fctFunction) }, false);
    else if (fctObj.attachEvent) fctObj.attachEvent(fctAct, function () {
        return eval(fctFunction)
    })
} document.write("<style type=\"text/css\"> body{FONT-FAMILY:\"\u5b8b\u4f53\";font-size:12px; line-height:20px;}.DateListBox{float:left;border:solid #FC7A7D 1px;width:147px !important;width:141px;height:168px !important;height:180px;font-size:12px;text-align:center;}.DateListBox h1{width:100%;background-color:#FFF4F4;color:#B42929;font-size:12px;height:20px;font-weight:bold;line-height:20px;vertical-align:middle;margin:0px;}.DateListBox div{float:left;border:solid #EB696C 1px; background-color:#EB696C;color:#FFFFFF;width:19px !important;width:18px;height:20px;font-size:12px;font-weight:bold;line-height:20px;vertical-align:middle;}.DateListBox a{float:left;color:#990000;border:solid #ffffff 1px;background-color:#ffffff;width:19px !important;width:20px;height:19px !important;height:19px;font-size:12px;line-height:20px;vertical-align:middle;}.DateListBox a:hover{border:solid #F2C2BD 1px;background-color:#FBEDEC;}.DateListBox .aSelect{cursor:pointer;border:solid #DEB4B4 1px;background-color:#FAE0CF;color:#FF0000;}.PyzyDateBox{position:absolute;z-index:11111;visibility:hidden;background-color:#FFFFFF;border:solid #EBcccC 1px;height:170px;width:298px !important;width:289px;}</style>"); function GetMonthHTML(K, D) {
    if (!D) D = new Date(); var I = D.getFullYear(), C = D.getMonth(), H = new Date(I, C + 1, 1), G = new Date(H - 86400000), F, B, A = ""; A += "<h1>" + I + "\u5e74" + (C + 1) + "\u6708</h1>"; A += "<div>\u65e5</div><div>\u4e00</div><div>\u4e8c</div><div>\u4e09</div><div>\u56db</div><div>\u4e94</div><div>\u516d</div>";
    for (var E = 1; E <= G.getDate(); E++) {
        F = new Date(I, C, E); B = F.getDay();
        if (E == 1) for (var J = 0; J < B; J++) A += "<a></a>"; A += "<a " + ((K && K != "") ? (F < K ? "old" : "") : "") + " href=javascript:; onclick='SelectDate(this)' title='" + I + "-" + (C + 1) + "-" + E + "'>" + E + "</a>"
    } return "<div class=\"DateListBox\">" + A + "</div>"
} function SelectDate(C) { if (C.href || C.className == "aSelect") { var B = document.getElementById("divPyzyDateBox").Obj, A = GetValueToInputObj(B); if (A) B = A; if (B.value == C.title) B.value = ""; else B.value = C.title; document.getElementById("divPyzyDateBox").style.visibility = "hidden"; document.getElementById("divPyzyDateBox").bodyclick = ""; GetPyzyIframe("ifmdivPyzyDateBox", "hidden"); AutoNextInputAct(document.getElementById("divPyzyDateBox").Obj, "click") } } function HiddenDateBox() { if (document.getElementById("divPyzyDateBox")) if (document.getElementById("divPyzyDateBox").style.visibility != "hidden" && document.getElementById("divPyzyDateBox").bodyclick == "1") { document.getElementById("divPyzyDateBox").style.visibility = "hidden"; document.getElementById("divPyzyDateBox").bodyclick = ""; GetPyzyIframe("ifmdivPyzyDateBox", "hidden") } else document.getElementById("divPyzyDateBox").bodyclick = "1" } function ShowTwoMonthList(I, D, J) { I = document.getElementById(I); if (!D) D = 0; if (!I) I = ""; var F = null, H = new Date(); if (J || J == "") { F = new Date(new Date() - 86400000); var C = J.split("-"); if (C.length == 3) F = new Date(C[0], parseInt(C[1], 10) - 1, C[2]); H = F; if (J == "") J = F.getFullYear() + "-" + (F.getMonth() + 1) + "-" + F.getDate() } var B = ""; for (var A = 0 + D; A < 2 + D; A++) B += GetMonthHTML((F ? F : ""), new Date(H.getFullYear(), H.getMonth() + A, 1)); if (F) B = B.replace(/old href/g, "style=color:#999 old"); if (I.value != "") if (/^((\d{4})|(\d{2}))-(\d{1,2})-(\d{1,2})$/g.test(I.value)) B = B.replace(I.value, I.value + "' class='aSelect"); var E = c$("divPyzyDateBox", "PyzyDateBox"); E.bodyclick = ""; if (I != "") { var G = getPosition(I); E.style.top = (G.top + G.height) + "px"; E.style.left = G.left + "px"; E.style.visibility = "visible"; E.Obj = I; GetPyzyIframe("ifmdivPyzyDateBox", "visible", (G.top + G.height), G.left, E.offsetWidth, E.offsetHeight) } E.innerHTML = B + "<div style=\"margin-top:0px;z-index: 1;left:5px;position:absolute;color:#B42929;font-size:12px;font-weight:bold;line-height:24px;vertical-align:bottom;\">&nbsp;<span style=\"padding-right:" + (document.all ? "220" : "232") + "px;cursor:pointer;\" onclick=\"ShowTwoMonthList(null," + (D - 1) + (J ? ",'" + J + "'" : "") + ")\" title=\"\u4e0a\u6708\"><--</span><span style=\"cursor:pointer;\" onclick=\"ShowTwoMonthList(null," + (D + 1) + (J ? ",'" + J + "'" : "") + ")\" title=\"\u4e0b\u6708\">--></span></div>" } function WriteCity(D) { var C = c$("divAddressMenu"), B = C.obj, A = document.getElementById("menuA" + D).title; A = A.split("|"); B.value = A[1]; var E = GetValueToInputObj(B); if (!E) { E = B; E.value = A[1] } else E.value = A[2]; if (typeof (D) == "number") AutoNextInputAct(B, "click") } function _Hidden(E) { E = E ? E : event; if (document.getElementById("divAddressMenu") != null) { var C = c$("divAddressMenu"), B = C.obj; if (C.style.visibility != "hidden") { if (E) { var A = (E.srcElement ? E.srcElement : E.target); if (B == A || A.id.indexOf("menuPage") == 0 || A.id.indexOf("divAddressMenu") == 0) return false } var D = GetValueToInputObj(B); if (document.getElementById("menuA1")) { if (!D) D = B; if (D.value == "" || D == B) WriteCity("1") } else if (A.id.indexOf("menuA") < 0) if (B) B.value = ""; C.style.visibility = "hidden"; GetPyzyIframe("ifm" + C.id, "hidden") } } } AddFunToObj(window, "onload", "AddFunToObj(document,'onclick','_Hidden(" + (document.all ? "" : "e") + ");HiddenDateBox();');"); function onloadTime() { var A = new Date(), B = A.getFullYear() + "-" + (A.getMonth() + 1) + "-" + A.getDate(), C = DateAdd("d", 2); C = C.getFullYear() + "-" + (C.getMonth() + 1) + "-" + C.getDate(); jQuery("#txtComeTime").val(B); jQuery("#txtLeaveTime").val(C) } function DateAdd(B, C) { var A = new Date(); switch (B) { case "s": return new Date(Date.parse(A) + (1000 * C)); case "n": return new Date(Date.parse(A) + (60000 * C)); case "h": return new Date(Date.parse(A) + (3600000 * C)); case "d": return new Date(Date.parse(A) + (86400000 * C)); case "w": return new Date(Date.parse(A) + ((86400000 * 7) * C)); case "q": return new Date(A.getFullYear(), (A.getMonth()) + C * 3, A.getDate(), A.getHours(), A.getMinutes(), A.getSeconds()); case "m": return new Date(A.getFullYear(), (A.getMonth()) + C, A.getDate(), A.getHours(), A.getMinutes(), A.getSeconds()); case "y": return new Date((A.getFullYear() + C), A.getMonth(), A.getDate(), A.getHours(), A.getMinutes(), A.getSeconds()) } } $(document).ready(function () { onloadTime() })