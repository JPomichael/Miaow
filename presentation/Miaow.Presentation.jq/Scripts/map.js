/*
* Copyright (c) 2010 iPow(www.iPow.cn)
*/
var map = null,
TimerControl = function (C, E) {
    var G, B, F = this;
    function A() { B = setTimeout(D, E) }
    function D() {
        if (F.run() === true) A(); else B = null
    }
    this.reset = function () { this.stop(); G = setTimeout(A, C) };
    this.run = function () { };
    this.stop = function () {
        if (G) {
            clearTimeout(G);
            G = null
        }
        if (B) {
            clearTimeout(B); B = null
        }
    }
};
function ddShow(D, B) {
    var C = ddControl.layer;
    ddControl.stop();
    if (C) C.style.display = "none";
    ddControl.layer = D;
    if (D)
        if (B) {
            var E = 20, A = 100;
            if (jQuery.browser.msie)
                D.style.filter = "alpha(opacity=" + E + ")";
            else
                D.style.opacity = E / 100;
            D.style.display = "";
            ddControl.from = E;
            ddControl.to = A;
            ddControl.reset()
        }
        else {
            if (jQuery.browser.msie)
                D.style.filter = "";
            else D.style.opacity = "";
            D.style.display = ""
        }
}
function iPowMap(A) {
    this.te = "";
    this.center = A.center;
    this.points = A.points;
    this.dom = A.dom
}

iPowMap.prototype = {
    initialize: function (A) {
        var B = this;
        map = new GMap2(document.getElementById("mapContainer"));
        B.setMap(); B.addPoint()
    },
    setMap: function () {
        var B = this, C = B.getPoints(), D = B.getBound(C), A = map.getDefaultUI();
        map.markers = {}; map.tipPanel = "MapTipPanel";
        map.setCenter(D.getCenter(), Math.min(map.getBoundsZoomLevel(D), 15));
        map.enableContinuousZoom();
        map.enableScrollWheelZoom();
        map.addControl(new GSmallMapControl())
    },
    getPoints: function () {
        var B = this, A = B.points, C = new Array();
        $.each(A, function (D, A) {
            if (A.Latitude && A.Latitude != 0 && A.Latitude != "") {
                var B = new GLatLng(A.Latitude, A.Longitude);
                A.point = B; C.push(A)
            }
        });
        return C
    },
    getBound: function (B) {
        var D = new GLatLngBounds(), A = false;
        for (var E = 0; E < B.length; E++) {
            var C = B[E].point;
            if (C) {
                A = true; D.extend(C)
            }
        }
        return A ? this.extendBound(D) : null
    },
    extendBound: function (D, A) {
        var E = D.toSpan(), C = D.getSouthWest(), B = D.getNorthEast(); return D
    },
    addPoint: function () {
        var B = this, A = B.points;
        SightMarker.resetMarkers(map, mapDataProcess(A))
     },
    showShape: function (A) { $("#shape" + A).trigger("mouseover") }
};


function SightMarker(A, C, D, B) {
    this.order = A;
    this.latlng = C;
    this.props = D;
    this.seq = D.seq;
    this.markers = B;
    this.markerPic = D.markerPic;
}
//SightMarker.prototype = new GOverlay();

SightMarker.prototype.initialize = function (E) {
    this._map = E; this.width = 27; this.height = 27;
    var A = this.props, C = "shape" + A.SightID,
        H = [];
    H.push("<span><a href=\"http://jq.ipow.cn/" + A.py + "\" target=\"_blank\" title=\"" + A.name + "\">" + this.seq + "</a></span>");
    var B = this.markerPanel = document.createElement("div");
    B.id = C;
    B.className = "mapLayerIco";
    B.innerHTML = H.join("");
    this._map.getPane(G_MAP_MARKER_PANE).appendChild(B);
    var G = this.label = $("#" + C).get(0), F = ["click", "dblclick", "mousedown", "mouseup"];
    for (var I = 0; I < F.length; I++) var D = F[I];
    if (jQuery.browser.msie) {
        GEvent.addDomListener(G, "mouseenter", newEventPassthru(this, "mouseenter", true));
        GEvent.addDomListener(G, "mouseleave", newEventPassthru(this, "mouseleave", true))
    }
    else {
        GEvent.addDomListener(G, "mouseover", fixEnterLeave(this, "mouseenter", true));
        GEvent.addDomListener(G, "mouseout", fixEnterLeave(this, "mouseleave", true))
    }
};
SightMarker.prototype.hideTip = function () { ddShow(null) };
SightMarker.prototype.redraw = function (B) {
    var A = this._map.fromLatLngToDivPixel(this.latlng);
    this.markerPanel.style.left = (A.x) + "px";
    this.markerPanel.style.top = (A.y) + "px";
    this.markerPanel.style.zIndex = 100 - this.seq
};
SightMarker.prototype.remove = function () {
    GEvent.clearInstanceListeners(this.markerPanel);
    GEvent.clearInstanceListeners(this.label);
    GEvent.clearInstanceListeners(this.mabel);
    if (this.markerPanel.outerHTML) this.markerPanel.outerHTML = "";
    if (this.markerPanel.parentNode) this.markerPanel.parentNode.removeChild(this.markerPanel);
    this.markerPanel = null; if (this.tipPanel) {
        GEvent.clearInstanceListeners(this.tipPanel);
        if (this.tipPanel.outerHTML) this.tipPanel.outerHTML = "";
        if (this.tipPanel.parentNode) this.tipPanel.parentNode.removeChild(this.tipPanel);
        this.tipPanel = null
    }
};
SightMarker.prototype.copy = function () {
    return new SightMarker(this.order, this.latlng, this.props)
};
var zindexId = 0; SightMarker.prototype.flickup = function () {
    if (this.markerPanel) {
        this.markerPanel.style.zIndex = 100 + (zindexId++);
        this.markerPanel.style.backgroundPosition = "left -28px"
    }
};
SightMarker.prototype.mouseenter = function () {
    this.flickup();
    var A = "#lisight" + this.props.SightID; $(A).css("background-color", "#ededed");
    SightMarker.showMarker(this.order, 400, true, this._map, this.markers)
};
SightMarker.prototype.mouseleave = function () {
    this.markerPanel.style.backgroundPosition = "left top";
    var A = "#lisight" + this.props.SightID; $(A).css("background-color", "#fff");
    SightMarker.showMarker(null, 200, true, this._map, this.markers)
};
SightMarker.resetMarkers = function (C, A) {
    var B = C.markers; for (var D in B) {
        C.removeOverlay(B[D]); C.clearOverlays()
    }
    $("#" + C.tipPanel).html("<div style=\"position:absolute;height:1px;width:1px;\"></div>");
    $.each(A, function (G, A) {
        var E = B[G] = new SightMarker(G, A.point, A, B), D = "lisight" + A.SightID;
        if (D) {
            var F = $("#" + D).get(0); GEvent.addDomListener(F, "mouseover", newEventPassthru(B[G], "mouseenter", true));
            GEvent.addDomListener(F, "mouseout", newEventPassthru(B[G], "mouseleave", true))
        } C.addOverlay(E)
    })
};
SightMarker.showMarker = function (D, E, A, C, B) {
    if (!E) E = 20; if (hm_worker) clearTimeout(hm_worker);
    hm_worker = setTimeout(function () { _showMarker(D, A, C, B) }, E)
};
SightMarker.setCenterAndZoom = function (A, B) {
    var C = getBound(B);
    A.setCenter(C.getCenter(), Math.min(A.getBoundsZoomLevel(C), 15))
};
var hm_worker = null; function _showMarker(C, B, E, D) {
    currentOrder = E.currentOrder; if (hm_worker) clearTimeout(hm_worker);
    hm_worker = null;
    if (C == E.currentOrder) return;
    if (E.currentOrder >= 0 && D[E.currentOrder]) D[E.currentOrder].hideTip(); if (C >= 0 && D[C]) {
        var F = D[C], G = E.getBounds();
        if (!G.containsLatLng(F.latlng)) {
            var A = GEvent.addListener(E, "moveend", function () { F.flickup(); GEvent.removeListener(A) });
            E.panTo(F.latlng)
        } else F.flickup()
    } E.currentOrder = C
}
function isChildOf(C, D, B) {
    while (D && D != C) {
        try { D = D.parentNode } catch (A) {
            return false
        }
    } return D == C
}
function newEventPassthru(C, A, B) {
    return function (D) {
        if (B && C[A]) C[A](D || window.event, this);
        else GEvent.trigger(C, A, D || window.event, this)
    }
} function fixEnterLeave(C, A, B) {
    return function (E) {
        var D = E.relatedTarget; if (this == D || isChildOf(this, D, A)) return;
        if (B && C[A]) C[A](E, this); else GEvent.trigger(C, A, E || window.event, this)
    }
}
function mapDataProcess(A) {
    var B = new Array();
     $.each(A, function (D, A) {
        if (A.Latitude && A.Latitude != 0 && A.Latitude != "") {
            var C = new GLatLng(A.Latitude, A.Longitude);
            A.point = C;
             if (A.OrderID && !isNaN(A.OrderID)) A.seq = A.OrderID; else A.seq = D + 1;
            A.hide = 0; B.push(A)
        }
    }); return B
}
var ddControl = new TimerControl(50, 50);

ddControl.run = function () {
    var A = this.layer; if (A && A.style.display == "") {
        this.from += 15; if (this.from > this.to) this.from = this.to; if (jQuery.browser.msie) {
            if (this.from >= 100) A.style.filter = ""; else A.style.filter = "alpha(opacity=" + this.from + ")"
        } else A.style.opacity = this.from / 100; if (this.from >= this.to) return false; else return true
    }
}
