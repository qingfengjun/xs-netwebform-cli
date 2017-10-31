$(document).ready(function () {
    setTableCss();
    setInputCss();
});
//为table设置变色
function setTableCss() {
    var xs_table_css = "xs_table"; //获取table的css
    var xs_table_th_css = "xs_table_th"; //table 的th样式
    var xs_table_even_css = "xs_table_even"; //table的偶数行css
    var xs_table_odd_css = "xs_table_odd"; //table的奇数行css
    var xs_table_select_css = "xs_table_select"; //table选择行的样式
    var xs_table = "table." + xs_table_css;
    $(xs_table).each(function () {
        $(this).children().children().has("th").addClass(xs_table_th_css); //表头
        var tr_even = $(this).children().children(":even").has("td"); //数据偶数行
        var tr_odd = $(this).children().children(":odd").has("td"); //数据奇数行
        tr_even.addClass(xs_table_even_css);
        tr_odd.addClass(xs_table_odd_css);
        tr_even.mouseover(function () {
            $(this).removeClass(xs_table_even_css);
            $(this).addClass(xs_table_select_css);
        });
        tr_even.mouseout(function () {
            $(this).removeClass(xs_table_select_css);
            $(this).addClass(xs_table_even_css);
        });
        tr_odd.mouseover(function () {
            $(this).removeClass(xs_table_odd_css);
            $(this).addClass(xs_table_select_css);
        });
        tr_odd.mouseout(function () {
            $(this).removeClass(xs_table_select_css);
            $(this).addClass(xs_table_odd_css);
        });

    });
}

//为文本框设置样式
function setInputCss() {
    //文本输入框
    $(".inputText").focusin(function () {
        $(this).removeAttr("class");
        //$(this).removeClass("inputText");
        $(this).addClass("inputTextFocus");
    }).focusout(function () {
        $(this).removeClass("inputTextFocus");
        $(this).addClass("inputText");
    });
}

//设置页面高度
function doSize() {
    window.parent.frames.doReSize();
}
//设置页面的跳转
function seturl(url) {
    window.parent.frames.setUrl(url);
}