
//定义请求（基本版）
//url==>请求地址，
//data==>参数
//method==>请求格式
//默认post请求
function Jajax(url, data, method) {
    var res;
    //Get请求
    if (method == "get") {
        $.get(url, data, function (result) {

            res = result;
        })
    } else {  //post
        $.post(url, data, function (result) {

            res = result;
        })
    }
    return res;
    //----END
}


//定义请求（底层版）
//url==>请求地址，
//data==>参数
//type==>请求格式
//dataType==>返回数据格式
function Dajax(url, data, dataType, type) {
    var res;
    $.ajax({
        type: type,
        url: url,
        async: false,
        data: data,
        dataType: dataType,
        success: function (data) {
            res = data

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //通常情况下textStatus和errorThrown只有其中一个包含信息
            this;   //调用本次ajax请求时传递的options参数
        }
    });
    return res;
}

//定义POST--formdata请求
//url请求地址
//data数据源 类型formdata格式 
//返回res对象，res.responseText属性为接口返回数据
function DajaxPostformdata(url, data) {
    var result;
    url = host + url;
    $.ajax({
        type: "post",
        url: url,
        data: data,
        async: false,
        dataType: "formData",
        cache: false,//上传文件无需缓存
        processData: false,//用于对data参数进行序列化处理 这里必须false
        contentType: false, //必须
    }).done(function (res) {
        result = res;
    }).fail(function (res) {
        result = res;
    });
}


$(function () {
    //添加弹出事件

    var zhi = "";
    zhi += " <div style='display: none;' id='xianshi'>"
    zhi += " <div class='mask' style='position: fixed;z-index: 1000;top: 0;right: 0;left: 0; bottom: 0;background: rgba(0, 0, 0, 0.6);'></div>";
    zhi += " <div style='position: fixed; z-index: 5000;width:80%;top: 44%;left: 50%;transform: translate(-50%, -50%);background-color: #FFFFFF;text-align: center;border-radius: 0.10667rem;overflow: hidden;'>";
    zhi += " <div class='modal-title' style='padding: 0.53333rem 0 0.28rem 0;font-family:PingFang SC Medium;font-size: 16px;color: #292929;'></div>";
    zhi += " <div class='modal-content'style='color: #373737; padding: 0 0.53333rem 0.41333rem;font-size: 16px;text-align: center;word-wrap: break-word;word-break: break-all;'>";

    zhi += "</div>";
    zhi += "<div style='color: #373737; padding: 0 0.53333rem 0.41333rem;font-size: 16px;text-align: center;word-wrap: break-word;word-break: break-all;'>";
    zhi += "<div style='margin-left:20%;float:left'> <input type='button' value='确认' id='btnqueren' onclick='Btnqueding()' style=' display: block;background-color: #5ba1e9;border: 1px solid #5ba1e9;color: #fff; width: 80px; height: 30px;line-height: 30px;border-radius: 4px;'/></div><div style='float:left;border-left:20px;margin:0px 10px'><input type='button' value='取消' id='quxiao'  style=' display: block;background-color: #5ba1e9;border: 1px solid #5ba1e9;color: #fff; width: 80px; height: 30px;line-height: 30px;border-radius: 4px;'/></div></div>";
    zhi += "</div>";
    zhi += "</div>";
    $("body").append(zhi);

    var tis = "";
    tis += " <div style='display: none;' id='tisshi'>"
    tis += " <div class='mask' style='position: fixed;z-index: 1000;top: 0;right: 0;left: 0; bottom: 0;background: rgba(0, 0, 0, 0);'></div>";
    tis += " <div style='position: fixed; z-index: 5000;width:80%;top: 44%;left: 50%;transform: translate(-50%, -50%);background-color: #292929bf;text-align: center;border-radius: 0.10667rem;overflow: hidden;'>";
    tis += " <div class='modal-title' style='padding: 0.53333rem 0 0.28rem 0;font-family:PingFang SC Medium;font-size: 16px;color: #292929;'></div>";
    tis += " <div class='modal-content'style='color: #373737; padding: 0 0.53333rem 0.41333rem;font-size: 16px;text-align: center;word-wrap: break-word;word-break: break-all;'>";

    tis += "</div>";
    tis += "<div style='color: #373737; padding: 0 0.53333rem 0.41333rem;font-size: 16px;text-align: center;word-wrap: break-word;word-break: break-all;'>";
    tis += "</div>";
    tis += "</div>";
    $("body").append(tis);


    $("#xianshi #quxiao").click(function () {
        $("#xianshi").css("display", "none");
    });
    //$("#xianshi #btnqueren").click(function () {
    //    var url = $("#xianshi #btnqueren").attr("status_url");
    //    var data = $("#xianshi #btnqueren").attr("status_data");
    //    if (typeof (data) != "undefined" && data != "") {
    //        location.href = url + "?" + data;
    //    } else {
    //        location.href = url;
    //    }
    //});
});

//弹出提示框
//content：输出内容
//url：跳转url
//title：标题
//value：跳转url传入的值
function OpenDialog(title, content, url, value) {
    $("#xianshi .modal-title").text(title);
    $("#xianshi .modal-content").text(content);
    $("#xianshi #btnqueren").attr("status_url", url).attr("status_data", value);
    $("#xianshi").css("display", "block");
}
//确订
function Btnqueding() {
    return true;
}

//弹出提示3S消失
//content：输出内容
//title：标题
//second 秒，默认3s
function Opentis(title, content, second) {
    $("#tisshi .modal-title").text(title);
    $("#tisshi .modal-content").text(content);
    if (typeof (second) != "undefined" && second != "")
        $("#tisshi").css("display", "block").fadeOut(second);
    else
        $("#tisshi").css("display", "block").fadeOut(3000);



}