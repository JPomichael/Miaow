$(document).ready(function () {
    $("#fname")
	.click(function () {
	    clearDefaultText(this, '上海欢乐谷');
	    $(this).attr("class", "inputText2");
	})
	.focus();

    //added by yjihrp 2011.9.6.20.22
    $('#createFroum').click(
    function () {
        window.location = '/forum/create?name=' + encodeURI($('#fname').val());
    });
});

function clearDefaultText(el, message) {
    var obj = el;
    if (typeof (el) == "string")
        obj = document.getElementById(id);
    if (obj.value == message) {
        obj.value = "";
    }
    obj.onblur = function () {
        if (obj.value == "") {
            obj.value = message;
            obj.className = "inputText2F";
        }
    }
}


