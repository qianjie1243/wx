//提示框（简单版提示框）
//该提示框事件
//一.提示框有确定按钮,确定按钮事件
//二.提示框无按钮
//三.提示框有确定，取消按钮,确定按钮事件
//四.三秒提示框（三秒后自动隐藏，用于提示如:已收藏...）
//五.动态加载提示   需要引用loader.min.css样式
//适用于手机端页面操作
//已从Common公用JS中转移独立JS中，方便引用，需要时引用，确保页面不要加载使用不到的操作
//-----------------
$(function () {
    //添加弹出事件

    var zhi = "";
    zhi += " <div style='display: none;' id='Dialog_xianshi'>"
    zhi +=
		" <div class='mask' style='position: fixed;z-index: 1000;top: 0;right: 0;left: 0; bottom: 0;background: rgba(0, 0, 0, 0.6);'></div>";
    zhi +=
		" <div style='position: fixed; z-index: 5000;width:80%;top: 44%;left: 50%;transform: translate(-50%, -50%);background-color: #FFFFFF;text-align: center;border-radius: 0.5rem;overflow: hidden;'>";
    zhi +=
		" <div class='modal-title' style='padding: 0.53333rem 0 0.28rem 0;font-family:PingFang SC Medium;font-size: 16px;color: #292929;'></div>";
    zhi +=
		" <div class='modal-content'style='color: #373737; padding: 0 0.53333rem 0.41333rem;font-size: 16px;text-align: center;word-wrap: break-word;word-break: break-all;'>";

    zhi += "</div>";
    zhi +=
		"<div class='cl' style='color: #373737; padding: 1.5rem 0.53333rem 1.5rem;font-size: 16px;text-align: center;word-wrap: break-word;word-break: break-all;'>";
    zhi +=
		"<div  id='Dialog_xianshi_type'> <bottom  id='btnqueren'  style=' display: block;background-color: #5ba1e9;border: 1px solid #5ba1e9;color: #fff; width: 80px; margin:auto;height: 30px;line-height: 30px;border-radius: 4px;'>确认</bottom></div></div>";
    zhi += "</div>";
    zhi += "</div>";
    $("body").append(zhi);



    var zhi1 = "";
    zhi1 += " <div style='display: none;' id='Dialog_xianshi1'>"
    zhi1 +=
		" <div class='mask' style='position: fixed;z-index: 1000;top: 0;right: 0;left: 0; bottom: 0;background: rgba(0, 0, 0, 0.6);'></div>";
    zhi1 +=
		" <div style='position: fixed; z-index: 5000;width:80%;top: 44%;left: 50%;transform: translate(-50%, -50%);background-color: #FFFFFF;text-align: center;border-radius: 0.5rem;overflow: hidden;'>";
    zhi1 +=
		" <div class='modal-title' style='padding: 0.53333rem 0 0.28rem 0;font-family:PingFang SC Medium;font-size: 16px;color: #292929;'></div>";
    zhi1 +=
		" <div class='modal-content'style='color: #373737; padding: 0 0.53333rem 0.41333rem;font-size: 16px;text-align: center;word-wrap: break-word;word-break: break-all;'>";

    zhi1 += "</div>";
    zhi1 +=
		"<div class='cl' style='color: #373737; padding: 1.5rem 0.53333rem 1.5rem;font-size: 16px;text-align: center;word-wrap: break-word;word-break: break-all;'>";
    zhi1 +=
		"<div style='display:flex'> <bottom  id='btnqueren'  style=' display: block;background-color: #5ba1e9;border: 1px solid #5ba1e9;color: #fff; width: 80px; margin:auto;height: 30px;line-height: 30px;border-radius: 4px;'>确认</bottom>";
    zhi1 +=
		"<bottom  id='btn_close'  style=' display: block;background-color: #5ba1e9;border: 1px solid #5ba1e9;color: #fff; width: 80px; margin:auto;height: 30px;line-height: 30px;border-radius: 4px;'>取消</bottom></div></div></div>";
    zhi1 += "</div>";
    zhi1 += "</div>";
    $("body").append(zhi1);

    var tis = "";
    tis += " <div style='display: none;' id='Dialog_tisshi'>"
    tis +=
		" <div class='mask' style='position: fixed;z-index: 1000;top: 0;right: 0;left: 0; bottom: 0;background: rgba(0, 0, 0, 0);'></div>";
    tis +=
		" <div style='position: fixed; z-index: 5000;width:40%;top: 44%;left: 50%;transform: translate(-50%, -50%);background-color: #292929bf;text-align: center;border-radius: 0.10667rem;overflow: hidden;border-radius:10px;'>";
    tis +=
		" <div class='modal-title' style='padding: 0.53333rem 0 0.28rem 0;font-family:PingFang SC Medium;font-size: 16px;color: #292929; color: white;'></div>";
    tis +=
		" <div class='modal-content'style='color: #373737; color: white; padding: 0 0.53333rem 0.41333rem;font-size: 16px;text-align: center;word-wrap: break-word;word-break: break-all;'>";

    tis += "</div>";
    tis +=
		"<div style='color: #373737; padding: 0 0.53333rem 0.41333rem;font-size: 16px;text-align: center;word-wrap: break-word;word-break: break-all;'>";
    tis += "</div>";
    tis += "</div>";
    $("body").append(tis);


    var Loader = "";
    Loader += '<div id="loader-wrapper">';
    Loader += '<div id="loader"></div>';
    Loader += '<div class="loader-section section-left"></div>';
    Loader += '<div class="loader-section section-right"></div>';
    Loader += '<div class="load_title" >正在加载中<br><span></span></div>';
    Loader += '</div>';
    $("body").append(Loader);

});



//弹出提示框(没有按钮,默认隐藏按钮)
//content：输出内容
//title：标题
//type true 显示确定按钮 false没有按钮
//fun 确定执行的方法

function OpenDialog(title, content, type, fun) {
    if (type)
        $("#Dialog_xianshi #Dialog_xianshi_type").show();
    else
        $("#Dialog_xianshi #Dialog_xianshi_type").hide();

    $("#Dialog_xianshi .modal-title").text(title);
    $("#Dialog_xianshi .modal-content").text(content);
    $("#Dialog_xianshi").show();

    $("#Dialog_xianshi #Dialog_xianshi_type #btnqueren").click(function () {
        if (fun)
            fun();

        $("#Dialog_xianshi").hide();
    })


}

//弹出提示框
//content：输出内容
//url：跳转url
//title：标题
//fun：确定执行的方法
function Dialog(title, content, fun) {
    $("#Dialog_xianshi1 .modal-title").text(title);
    $("#Dialog_xianshi1 .modal-content").text(content);
    $("#Dialog_xianshi1").show();

    $("#Dialog_xianshi1 #btn_close").click(function () {
        $("#Dialog_xianshi1").hide();
    })
    $("#Dialog_xianshi1 #btnqueren").click(function () {
        if (fun)
            fun(); //执行方法

        $("#Dialog_xianshi1").hide(); //隐藏
    })
}

//弹出提示3S消失
//content：输出内容
//title：标题
//second 秒，默认3s
function Opentis(title, content, second) {
    $("#Dialog_tisshi .modal-title").text(title);
    $("#Dialog_tisshi .modal-content").text(content);
    if (typeof (second) != "undefined" && second != "")
        $("#Dialog_tisshi").css("display", "block").fadeOut(second);
    else
        $("#Dialog_tisshi").css("display", "block").fadeOut(3000);
}


//显示加载动画
function loaded() {
    $("#loader-wrapper").show();
}
//隐藏加载动画
function closeloaded() {
    $("#loader-wrapper").hide();
}