// JavaScript Document
function navList() {
    var $obj = $("#J_navlist");
    $obj.find("h4").hover(function () {
        $(this).addClass("hover");
    }, function () {
        $(this).removeClass("hover");
    });
    $obj.find("p").hover(function () {
        if ($(this).hasClass("on")) { return; }
        $(this).addClass("hover");
    }, function () {
        if ($(this).hasClass("on")) { return; }
        $(this).removeClass("hover");
    });
    $obj.find("h4").click(function () {
        var $div = $(this).siblings(".list-item");
        if ($(this).parent().hasClass("selected")) {
            $div.slideUp(600);
            $(this).parent().removeClass("selected");
        }
        if ($div.is(":hidden")) {
            $("#J_navlist li").find(".list-item").slideUp(600);
            $("#J_navlist li").removeClass("selected");
            $(this).parent().addClass("selected");
            $div.slideDown(600);

        } else {
            $div.slideUp(600);
        }
    });
}

//≤Àµ•—°‘Ò”“±ﬂ“≥√Ê
function setUrl(url) {
    $("#ipage").attr("src", url);
    return false;
}

$(document).ready(function () {
    $("#ipage").load(function () {
        doReSize();
    });
    window.onresize = function () {
        doReSize();
    }
});

function doReSize() {
    var panding = 20;
    var clientHeight = $("#ipage").contents().find("body").height() + panding;
    $("#ipage").height(clientHeight);
    var divHeight = $("#location").height();
    $("#ContentPlace").height(clientHeight + divHeight + 22);
}
