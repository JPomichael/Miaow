function GoUp(id, type) {
    var data = new Date();

    var url = "/up/";
    if (type == "wave") {
        url += id + "/" + type;
    } else if (type == "up") {

        url += id + "/" + type;
    } else if (type == "down") {

        url += id + "/" + type;
    }
    $.getJSON(url, null, function (data) {

        if (type == "wave") {
            $("#" + type + id).html("飘过" + data.count);
        } else if (type == "up") {

            $("#" + type + id).html("顶" + data.count);
        } else if (type == "down") {

            $("#" + type + id).html("砸" + data.count);
        }

    });
}

$(function () {
    var f = false;
    $("#submit_form1").submit(function () {
        var title = $("#title").val();
        var content = $("#content").val();
        var fid = $("#fid").val();

        var picurl = $("#pic").val();

        if ($.trim(title) == "") {
            alert("请输入帖子标题!");
            return false;
        }
        if ($.trim(title).length < 5) {
            alert("帖子标题太短!");
            return false;
        }
        if ($.trim(content) == "") {
            alert("请输入帖子内容!");
            return false;
        } else {

            $.post("/Admin/CheakVcode", { key: $("#verifyNum1").val() }, function (data) {

                if (data.Success == false) {

                    $("#IdMessage").html("验证码输入错误!");
                } else {

                    $("#IdMessage").html("");

                    $.ajax({
                        type: "Post",
                        data: { title: title, picurl: picurl, content: content, fid: fid },
                        datatype: null,
                        url: "/AddTopic/AddFromTopic",
                        success: function (data) {
                            alert("发帖成功!");
                            $("#divFroum").html(data);
                            $("#content").val("");
                            $("#title").val("");
                        }
                    });

                }
            });





        }
    });
});

$(function () {
    $("#submit_form").submit(function () {

        var tid = $("#tid").val();
        var fid = $("#fid").val();
        var content = $("#content").val();
        var picurl = $("#pic").val();
        var anony = $("#anony").val();
        if ($.trim(content) == "") {
            alert("请输入回帖内容!");
            return false;
        } else {

            $.post("/Admin/CheakVcode", { key:$("#verifyNum1").val()  }, function (data) {

                if (data.Success == false) {

                    $("#IdMessage").html("验证码输入错误!");
                } else {

                    $("#IdMessage").html("");

                    $.ajax({
                        type: "Post",
                        data: { content: content, picurl: picurl, tid: tid, fid: fid, anony: anony },
                        datatype: null,
                        url: "/AddTopic/AddFromTopic",
                        success: function (data) {
                            alert("回帖成功!");
                            //                    $("#leftmain").html("");
                            $("#divFroum").html(data);
                            $("#content").val("");
                        }
                    });


                }
            });



        }
    });

    $("#Logon-vcode").click(function () {
        var dt = new Date()
        $("#Logon-vcode").attr("src", "/Admin/Vcode/Logon?d=" + dt.toString());
    });
    $("#verifyNum1").blur(function () {
        $.post("/Admin/CheakVcode", { key: $(this).val() }, function (data) {

            if (data.Success == false) {
                $("#IdMessage").html("验证码输入错误!");
            } else {
                $("#IdMessage").html("");
            }
        });
    });

});