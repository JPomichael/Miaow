function setSearchDay(name, selected, count) {
    for (i = 1; i <= count; i++) {
        var menu = $("#" + name + i);
        if (i == selected) {
            menu.removeClass();
            menu.addClass("munshu");
            $('#txtDays').attr('value', i);
        }
        else {
            menu.removeClass();
        }
    }
}

function searchCheckedForm() {
    var res = true;
    if ($('#txtSearch').val() == '' || $('#txtSearch').val() == '输入关键字，海南、桂林、京、上海、  没想到就输入不知道') {
        $('#txtBide').focus();
        alert('目的地不能为空');
        res = false;
    }
    return res;
}

$(function () {
    $('#priceFirst').click(function () {
        $('#txtMoney').attr('value', 0);
        $('#money').html('¥0');
        $('#searchPricePoint').css('margin-left', '-100px');
    });

    $('#priceTwo').click(function () {
        $('#txtMoney').attr('value', 500);
        $('#money').html('¥500');
        $('#searchPricePoint').css('margin-left', '-80px');
    });

    $('#priceThr').click(function () {
        $('#txtMoney').attr('value', 1475);
        $('#money').html('¥1475');
        $('#searchPricePoint').css('margin-left', '-55px');
    });

    $('#priceFour').click(function () {
        $('#txtMoney').attr('value', 3000);
        $('#money').html('¥3000');
        $('#searchPricePoint').css('margin-left', '-30px');
    });

    $('#priceFive').click(function () {
        $('#txtMoney').attr('value', '5000');
        $('#money').html('¥5000+');
        $('#searchPricePoint').css('margin-left', '-10px');
    });




});



