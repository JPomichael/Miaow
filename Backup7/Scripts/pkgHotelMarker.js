/*
* Compressed by iPow(www.iPow.cn)
*/
var TimerControl = function (G, A) {
    var D, E, C = this; function B() { E = setTimeout(F, A) }
    function F() { if (C.run() === true) B(); else E = null }
    this.reset = function () { this.stop(); D = setTimeout(B, G) };
    this.run = function () { };
    this.stop = function () {
        if (D) { clearTimeout(D); D = null }
        if (E) { clearTimeout(E); E = null }
    }
};
function isChildOf(A, B, C) {
    while (B && B != A) { try { B = B.parentNode } catch (D) { return false } } return B == A
} function newEventPassthru(A, B, C) { return function (D) { if (C && A[B]) A[B](D || window.event, this); else GEvent.trigger(A, B, D || window.event, this) } } function fixEnterLeave(A, B, C) { return function (E) { var D = E.relatedTarget; if (this == D || isChildOf(this, D, B)) return; if (C && A[B]) A[B](E, this); else GEvent.trigger(A, B, E || window.event, this) } } function getPriceStyle(A) { if (A <= 200) return "colorS"; else if (A > 200 && A <= 300) return "colorM"; else if (A > 300 && A <= 500) return "colorL"; else return "colorXL" } function HotelMarker(C, B, A) { this.order = C; this.latlng = B; this.props = A; this.seq = A.seq } var markerID = 0; HotelMarker.prototype = new GOverlay(); HotelMarker.prototype.initialize = function (K) { this.map = K; var A = this.props, H = null; this.width = 21; this.height = 25; this.width = 19; this.height = 22; var B = "hmk" + (markerID++), J = "hmm" + (markerID++), C = []; C.push("<span  id=\"", J, "\"  class=\"left\"><a target=\"_blank\" href=\"", A.Url, "\">", this.seq + "</a></span>"); C.push("<span class=\"right\" id=\"", B, "\">"); if (A.Type == "Sight") C.push(" <span  ", " class=\"bar_bg1 colorXL\"><a target=\"_blank\" href=\"", A.Url, "\">", A.Name, "</a></span>"); if (A.Type == "Hotel") C.push(" <span  id=\"", B, "\" class=\"bar_bg1 ", getPriceStyle(A.Price), "\"><a target=\"_blank\" href=\"", A.Url, "\">\xa5", A.Price, "</span>"); C.push("</span>"); var F = this.markerPanel = document.createElement("div"); F.className = "link_icon"; F.innerHTML = C.join(""); K.getPane(G_MAP_MARKER_PANE).appendChild(F); var I = this.label = $("#" + B).get(0), E = this.mabel = $("#" + J).get(0), D = ["click", "dblclick", "mousedown", "mouseup"]; for (var G = 0; G < D.length; G++) { var L = D[G]; GEvent.addDomListener(I, L, newEventPassthru(this, L)); GEvent.addDomListener(E, L, newEventPassthru(this, L)) } if (jQuery.browser.msie) { GEvent.addDomListener(I, "mouseenter", newEventPassthru(this, "mouseenter", true)); GEvent.addDomListener(I, "mouseleave", newEventPassthru(this, "mouseleave", true)); GEvent.addDomListener(E, "mouseenter", newEventPassthru(this, "mouseenter", true)); GEvent.addDomListener(E, "mouseleave", newEventPassthru(this, "mouseleave", true)) } else { GEvent.addDomListener(I, "mouseover", fixEnterLeave(this, "mouseenter", true)); GEvent.addDomListener(I, "mouseout", fixEnterLeave(this, "mouseleave", true)); GEvent.addDomListener(E, "mouseover", fixEnterLeave(this, "mouseenter", true)); GEvent.addDomListener(E, "mouseout", fixEnterLeave(this, "mouseleave", true)) } }; HotelMarker.prototype.showTip = function (E) { if (!this.tipPanel) { var A = this.props, D = this.tipPanel = document.createElement("div"); D.className = "icon_right1"; var B = ""; if (A.Type == "Sight") { B = ["<div class=\"top\">", "<div style=\"clear: both; width: 100%;\" class=\"bar_bg4\">"]; B.push("<span style=\"padding: 0px 5px; float: left;\">", A.Name, "</span>"); B.push("<span style=\"float:right;padding-right:3px;\">", A.Price > 0 ? "\xa5" + A.Price : "\u514d\u8d39", "</span>"); B.push("</div>"); B.push("<div class=\"bottom\">"); B.push("<span class=\"font1\">\u666f\u533a\u7c7b\u522b\uff1a", A.SightType, "</span>"); B.push("<span class=\"font2\" >\u5730\u5740\uff1a", A.Address, "</span>"); B.push("<img src=\"", A.ImageSrc, "\" class=\"ico\"/>"); B.push("<span class=\"spanIco\">"); B.push("<em class=\"emComm\">", A.CommCount, "</em>"); B.push("<em class=\"emImg\">", A.PicCount, "</em>"); B.push(" </span>"); B.push(" <a target=\"_blank\" href=\"", A.Url, "\" class=\"mapLook\">\u67e5\u770b</a>"); B.push("</div>"); B.push("</div>") } if (A.Type == "Hotel") { B = ["<div class=\"top\">", "<div style=\"clear: both; width: 100%;\" class=\"bar_bg4 ", getPriceStyle(A.Price), "\">"]; B.push("<span style=\"padding: 0px 5px; float: left;\">\xa5", A.Price, "</span>"); B.push("<span style=\"float:right;padding-right:3px;\">", A.HotelType, "</span>"); B.push("</div>"); B.push("<div class=\"bottom\">"); B.push("<span class=\"font1\">", A.Name, "</span>"); B.push("<span class=\"font2\" >\u5730\u5740\uff1a", A.Address, "</span>"); B.push("<img src=\"", A.ImageSrc, "\" class=\"ico\"/>"); B.push("<span class=\"spanIco\">"); B.push("<em class=\"emComm\">", A.CommCount, "</em>"); B.push("<em class=\"emImg\">", A.PicCount, "</em>"); B.push(" </span>"); B.push(" <a target=\"_blank\" href=\"", A.Url, "\" class=\"mapLook\">\u9884\u5b9a</a>"); B.push("</div>"); B.push("</div>") } D.innerHTML = B.join(""); $("#jxMapTipPanel").append(D); if (jQuery.browser.msie) $("#jxMapTipPanel").get(0).style.display = ""; if (jQuery.browser.msie) { GEvent.addDomListener(D, "mouseenter", newEventPassthru(this, "mouseenter", true)); GEvent.addDomListener(D, "mouseleave", newEventPassthru(this, "mouseleave", true)) } else { GEvent.addDomListener(D, "mouseover", fixEnterLeave(this, "mouseenter", true)); GEvent.addDomListener(D, "mouseout", fixEnterLeave(this, "mouseleave", true)) } } var C = this.map.fromLatLngToContainerPixel(this.latlng); this.tipPanel.style.left = (C.x + this.width - 1) + "px"; this.tipPanel.style.top = (C.y - 22) + "px"; this.tipPanel.style.zIndex = this.markerPanel.style.zIndex + 1; ddShow(this.tipPanel, E) };
HotelMarker.prototype.hideTip = function () { ddShow(null) };
HotelMarker.prototype.redraw = function (B) {
    var A = this.map.fromLatLngToDivPixel(this.latlng);
    this.markerPanel.style.left = (A.x) + "px"; this.markerPanel.style.top = (A.y - this.height) + "px";
    this.markerPanel.style.zIndex = 100 - this.seq
};
HotelMarker.prototype.remove = function () {
    GEvent.clearInstanceListeners(this.markerPanel); GEvent.clearInstanceListeners(this.label);
    GEvent.clearInstanceListeners(this.mabel); if (this.markerPanel.outerHTML) this.markerPanel.outerHTML = "";
    if (this.markerPanel.parentNode) this.markerPanel.parentNode.removeChild(this.markerPanel);
    this.markerPanel = null; if (this.tipPanel) {
        GEvent.clearInstanceListeners(this.tipPanel);
        if (this.tipPanel.outerHTML) this.tipPanel.outerHTML = "";
        if (this.tipPanel.parentNode) this.tipPanel.parentNode.removeChild(this.tipPanel);
        this.tipPanel = null
    }
};
HotelMarker.prototype.copy = function () { return new HotelMarker(this.order, this.latlng, this.props) };
var zindexId = 0;
HotelMarker.prototype.flickup = function () { if (this.markerPanel) this.markerPanel.style.zIndex = 100 + (zindexId++) };
HotelMarker.prototype.mouseenter = function () { this.flickup(); HotelMarker.showMarker(this.order, 400, true) };
HotelMarker.prototype.mouseleave = function () { HotelMarker.showMarker(null, 200) };
var markers = {};
HotelMarker.resetMarkers = function (F, E) {
    for (var B in markers) { F.removeOverlay(markers[B]); F.clearOverlays() }
    $("#jxMapTipPanel").html("<div style=\"position:absolute;height:1px;width:1px;\"></div>"); markers = {};
    for (B = 0; B < E.length; B++) {
        var A = E[B]; if (A.point) {
            var C = markers[B] = new HotelMarker(B, A.point, A);
            if (A.DomID) {
                var D = $("#" + A.DomID).get(0);
                GEvent.addDomListener(D, "mouseover", newEventPassthru(markers[B], "mouseenter", true));
                GEvent.addDomListener(D, "mouseout", newEventPassthru(markers[B], "mouseleave", true))
            } F.addOverlay(C)
        }
    }
};
var currentOrder = null, hm_worker = null; function _showMarker(D, C) {
    if (hm_worker) clearTimeout(hm_worker);
    hm_worker = null; if (D == currentOrder) return;
    if (currentOrder >= 0 && markers[currentOrder]) markers[currentOrder].hideTip();
    if (D >= 0 && markers[D]) {
        var A = markers[D], E = map.getBounds();
        if (!E.containsLatLng(A.latlng)) {
            var B = GEvent.addListener(map, "moveend", function () {
                A.flickup();
                A.showTip(C); GEvent.removeListener(B)
            }); map.panTo(A.latlng)
        } else { A.flickup(); A.showTip(C) }
    }
    currentOrder = D
} HotelMarker.showMarker = function (A, C, B) {
    if (!C) C = 20; if (hm_worker) clearTimeout(hm_worker);
    hm_worker = setTimeout(function () { _showMarker(A, B) }, C)
};
HotelMarker.setCenterAndZoom = function (B, A) {
    var C = getBound(A); B.setCenter(C.getCenter(), Math.min(B.getBoundsZoomLevel(C), 15))
};
var ddControl = new TimerControl(50, 50); ddControl.run = function () {
    var A = this.layer;
    if (A && A.style.display == "") {
        this.from += 15; if (this.from > this.to) this.from = this.to;
        if (jQuery.browser.msie) {
            if (this.from >= 100) A.style.filter = "";
            else A.style.filter = "alpha(opacity=" + this.from + ")"
        } else A.style.opacity = this.from / 100;
        if (this.from >= this.to) return false; else return true
    }
}; function ddShow(E, D) {
    var B = ddControl.layer; ddControl.stop(); if (B) B.style.display = "none"; ddControl.layer = E;
    if (E) if (D) {
        var C = 20, A = 100; if (jQuery.browser.msie) E.style.filter = "alpha(opacity=" + C + ")";
        else E.style.opacity = C / 100; E.style.display = ""; ddControl.from = C; ddControl.to = A; ddControl.reset()
    }
    else { if (jQuery.browser.msie) E.style.filter = ""; else E.style.opacity = ""; E.style.display = "" } 
} function getBound(B) { var E = new GLatLngBounds(), D = false; for (var A = 0; A < B.length; A++) { var C = B[A].point; if (C) { D = true; E.extend(C) } } return D ? extendBound(E) : null } function extendBound(E, C) { var D = E.toSpan(), B = E.getSouthWest(), A = E.getNorthEast(); return E } var map, geocoder, globalMapData, hotels, mapInital = false, OLD_LEVEL, OLD_CENTER, enableDrag = false;
function mapinitialize(C) {
    mapInital = true; var B = jQuery("#showmode").val();
    map = new GMap2(document.getElementById("gMap"));
    map.addControl(new GSmallMapControl()); var A = mapDataProcess(C), D = getBound(A); map.setCenter(D.getCenter(), Math.min(map.getBoundsZoomLevel(D), 15)); map.enableContinuousZoom(); map.enableScrollWheelZoom(); HotelMarker.resetMarkers(map, A);
    if (enableDrag && enableDrag == true) GEvent.bind(map, "moveend", map, function (C) {
        var E = extendBound(map.getBounds()); map.reDraw = false; OLD_CENTER = map.getCenter(); OLD_LEVEL = map.getZoom();
        jQuery.each(globalMapData, function (A, B) { var C = new GLatLng(B.Latitude, B.Longitude); globalMapData[A].outBound = !(C && E.containsLatLng(C)); if (!globalMapData[A].hide) globalMapData[A].hide = 0 }); A = new Array(); for (var D = 0; D < globalMapData.length; D++) if (!globalMapData[D].outBound && globalMapData[D].hide == 0) A.push(globalMapData[D]); tempMapData = A; $("#ResultCount").text(tempMapData.length); if (globalMapData[0].Type == "Sight") rPage(0, 10, 1); if (globalMapData[0].Type == "Hotel") rhPage(0, 10, 1, B)
    })
}
function mapDataProcess(B) { var A = new Array(); $.each(B, function (B, C) { if (C.Latitude && C.Latitude != 0 && C.Latitude != "") { var D = new GLatLng(C.Latitude, C.Longitude); C.point = D; C.order = B; C.seq = B + 1; C.hide = 0; A.push(C) } }); return A }
var filterManager = this.filterManager = new function () {
    this.filters = { "price": function (F, D, E) { var B = 1; for (var C = 0; C < globalMapData.length; C++) { var G = parseInt(globalMapData[C].Price); if (G >= D && G <= E) globalMapData[C].hide &= ~(1 << B); else globalMapData[C].hide |= 1 << B } A() }, "star": function (D, E) { var B = 2; for (var C = 0; C < globalMapData.length; C++) { var F = globalMapData[C].star.num; if (F >= D && F <= E) globalMapData[C].hide &= ~(1 << B); else globalMapData[C].hide |= 1 << B } A() }, "stars": function (F, D) { var B = 3; for (var C = 0; C < globalMapData.length; C++) { var E = (D.length == 0); if (!E) { var G = globalMapData[C].HotelType; if (G == D) globalMapData[C].hide &= ~(1 << B); else globalMapData[C].hide |= 1 << B } } A() }, "fea": function (D) { var B = 4; for (var C = 0; C < globalMapData.length; C++) if (!D || ((globalMapData[C].fea & D) >= D)) globalMapData[C].hide &= ~(1 << B); else globalMapData[C].hide |= 1 << B; A() }, "brand": function (D) { var B = 5, E = {}; for (var C = 0; C < D.length; C++) E[D[C]] = true; for (C = 0; C < globalMapData.length; C++) if (D.length == 0 || E[globalMapData[C].bid]) globalMapData[C].hide &= ~(1 << B); else globalMapData[C].hide |= 1 << B; A() }, "point": function (D) { if (D === false); else if (D) { filterManager.pointFiltered = true; for (var B = 0; B < globalMapData.length; B++) { var C = globalMapData[B].point; globalMapData[B].outBound = !(C && D.containsLatLng(C)) } } else for (B = 0; B < globalMapData.length; B++) globalMapData[B].outBound = !globalMapData[B].point; A() }, "order": function (J, H, E) { var I, B = 7; H = "Price"; E = parseInt(E); var G = globalMapData; switch (E) { case 0: for (var C = 1; C < globalMapData.length; ++C) { var F = C, D = globalMapData[C]["" + H + ""]; while (F > 0 && globalMapData[F - 1]["" + H + ""] > D) { globalMapData[F] = globalMapData[F - 1]; --F } } A(); break; case 1: break; default: break } } };
    function A() { var B = jQuery("#showmode").val(); filtered = []; var C = 0; for (var A = 0; A < globalMapData.length; A++) { var D = (globalMapData[A].hide != 0); if (!D) C++; if (!D && !globalMapData[A].outBound) filtered.push(globalMapData[A]) } tempMapData = filtered; rhPage(0, 10, 1, B) } this.doFilter = function (A) { this.filters[A].apply(this, arguments) } 
}