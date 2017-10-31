//****************************************************************************************
//作者：轻狂书生
//博客地址：http://www.cnblogs.com/xiaoshuai1992
//create: 2014/5/30
//功能：实现弹出层和其拖拽效果
//使用方法：$("*").xsPop(options);
//*****************************************************************************************


(function ($) {
    var clientHeight, clientWidth;
    $.fn.xsPop = function (options) {
        var defaults = {//默认值
            title: "弹出窗口", //窗口标题
            width: 500,
            heigth: 400,
            tag: this, //弹出需要加载的元素
            close: "关闭",
            mainContent: "body"//容器,为了可以提交表单，不过submit会刷新页面...

        };
        var options = $.extend(defaults, options); //以传参覆盖
        this.each(function () {
            xsMain(options.title, options.width, options.heigth, options.tag, options.close, options.mainContent); //插件的主入口
        });
    };

    //根据传入数据,添加遮罩层,弹出提示框
    function xsMain(title, width, height, tag, close, mainContent) {
        var divmask = "<div class=\"mask\"></div>";
        $(mainContent).append(divmask);
        var xsPop1 = " <div id=\"xsPop\" class=\"PopUp\"> <div class=\"PopHead\" id=\"xsPopHead\">";
        var xsPop2 = " <b>" + title + " </b><span id=\"xsColse\">" + close + "</span>";
        var xsPop3 = "  </div>  <div class=\"PopMain\" id=\"xsPopMain\">";
        var xsPop5 = "</div><span id=\"xytest\"></span> </div>";
        var allHtml = xsPop1 + xsPop2 + xsPop3 + xsPop5;
        $(mainContent).append(allHtml);
        $(tag).show();
        $(tag).appendTo("#xsPopMain");

        //得到浏览器的高度和宽度,进行后面判断(高度超过，拖动边框限制)
        clientHeight = window.screen.height;
        clientWidth = window.screen.width;

        if (height > clientHeight) {
            height = clientHeight - 100;
        }
        if (width > clientWidth) {
            width = clientWidth - 100;
        }

        $("#xsPop").css({
            "heigth": height + "px",
            "width": width + "px",
            "margin-top": "-" + (height / 2) + "px",
            "margin-left": "-" + (width / 2) + "px"
        });
        $("#xsPopMain").css("height", height - $("#xsPopHead").height());
        xsdrag("#xsPopHead", "#xsPop"); //绑定拖动动作
        $("#xsColse").bind("click", function () { ClosePop(tag, mainContent); }); //绑定关闭动作
    }

    //关闭弹出层
    function ClosePop(tag, mainContent) {
        $(mainContent).append(tag); //保存，不然第四步的 $("#xsPop").remove()会把tag清空掉
        $(tag).hide();
        $(".mask").remove();
        $("#xsPop").remove();
    }

    //弹出层的拖拽（失败的方法，会出现对象丢失）
    //control 为拖拽的元素，tag为动作的元素，一般control在tag内
    //    function drag(control, tag) {
    //        var isMove = false;
    //        var abs_x = 0, abs_y = 0;
    //        $(control).mousedown(
    //            function (event) {
    //                var top = $(tag).offset().top;
    //                var left = $(tag).offset().left;
    //                abs_x = event.pageX - left;
    //                abs_y = event.pageY - top;
    //                isMove = true;
    //            }).mouseleave(function () {
    //                isMove = false;
    //            });
    //        $(control).mouseup(function () {
    //            isMove = false;
    //        });

    //        $(document).mousemove(function (event) {
    //            if (isMove) {
    //                $(tag).css({
    //                    'left': event.pageX - abs_x + $(tag).width() / 2 - 1,
    //                    'top': event.pageY - abs_y + $(tag).height() / 2 - 1
    //                });
    //            }
    //            return false;
    //        });
    //    }

    //弹出层的拖拽
    //control 为拖拽的元素，tag为动作的元素，一般control在tag内
    function xsdrag(control, tag) {
        $(control).mousedown(function (e)//e鼠标事件  
        {
            var offset = $(this).offset(); //DIV在页面的位置  
            var x = e.pageX - offset.left; //获得鼠标指针离DIV元素左边界的距离  
            var y = e.pageY - offset.top; //获得鼠标指针离DIV元素上边界的距离  
            $(document).bind("mousemove", function (ev)//绑定鼠标的移动事件，因为光标在DIV元素外面也要有效果，所以要用doucment的事件，而不用DIV元素的事件  
            {
                if (ev.pageY <= 0) { return; }//防止边框超过屏幕后无法关闭和拖动
                $(tag).css({
                    'left': ev.pageX - x + $(tag).width() / 2, //本人的布局需要加这个
                    'top': ev.pageY - y + $(tag).height() / 2
                });
            });

        });
        $(document).mouseup(function () {
            $(this).unbind("mousemove");
        });
    }
})(jQuery);
