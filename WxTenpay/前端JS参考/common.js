var host = "";//请求后台url


//定义请求（基本版）
//url==>请求地址，
//data==>参数
//method==>请求格式
//默认post请求
$.ajaxSettings.async = false;//设置同步请求
function Jajax(url, data, method) {
    url = host + url;
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
        url: host + url,
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
    zhi += " <div style='position: fixed; z-index: 5000;width:80%;top: 44%;left: 50%;transform: translate(-50%, -50%);background-color: #FFFFFF;text-align: center;border-radius: 0.5rem;overflow: hidden;'>";
    zhi += " <div class='modal-title' style='padding: 0.53333rem 0 0.28rem 0;font-family:PingFang SC Medium;font-size: 16px;color: #292929;'></div>";
    zhi += " <div class='modal-content'style='color: #373737; padding: 0 0.53333rem 0.41333rem;font-size: 16px;text-align: center;word-wrap: break-word;word-break: break-all;'>";

    zhi += "</div>";
    zhi += "<div class='cl' style='color: #373737; padding: 1.5rem 0.53333rem 1.5rem;font-size: 16px;text-align: center;word-wrap: break-word;word-break: break-all;'>";
    zhi += "<div> <input type='button' value='确认' id='btnqueren'  style=' display: block;background-color: #5ba1e9;border: 1px solid #5ba1e9;color: #fff; width: 80px; margin:auto;height: 30px;line-height: 30px;border-radius: 4px;'/></div></div>";
    zhi += "</div>";
    zhi += "</div>";
    $("body").append(zhi);

    var zhi1 = "";
    zhi1 += " <div style='display: none;' id='xianshi1'>"
    zhi1 += " <div class='mask' style='position: fixed;z-index: 1000;top: 0;right: 0;left: 0; bottom: 0;background: rgba(0, 0, 0, 0.6);'></div>";
    zhi1 += " <div style='position: fixed; z-index: 5000;width:80%;top: 44%;left: 50%;transform: translate(-50%, -50%);background-color: #FFFFFF;text-align: center;border-radius: 0.5rem;overflow: hidden;'>";
    zhi1 += " <div class='modal-title' style='padding: 0.53333rem 0 0.28rem 0;font-family:PingFang SC Medium;font-size: 16px;color: #292929;'></div>";
    zhi1 += " <div class='modal-content'style='color: #373737; padding: 0 0.53333rem 0.41333rem;font-size: 16px;text-align: center;word-wrap: break-word;word-break: break-all;'>";

    zhi1 += "</div>";
    zhi1 += "<div class='cl' style='color: #373737; padding: 1.5rem 0.53333rem 1.5rem;font-size: 16px;text-align: center;word-wrap: break-word;word-break: break-all;'>";
    zhi1 += "<div style='display:flex'> <input type='button' value='确认' id='btnqueren'  style=' display: block;background-color: #5ba1e9;border: 1px solid #5ba1e9;color: #fff; width: 80px; margin:auto;height: 30px;line-height: 30px;border-radius: 4px;'/>";
    zhi1 += "<input type='button' value='取消' id='btn_close'  style=' display: block;background-color: #5ba1e9;border: 1px solid #5ba1e9;color: #fff; width: 80px; margin:auto;height: 30px;line-height: 30px;border-radius: 4px;'/></div></div></div>";
    zhi1 += "</div>";
    zhi1 += "</div>";
    $("body").append(zhi1);

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

});

//弹出提示框
//content：输出内容
//url：跳转url
//title：标题
//value：跳转url传入的值
function OpenDialog(title, content) {
    $("#xianshi .modal-title").text(title);
    $("#xianshi .modal-content").text(content);
    $("#xianshi").show();
}

//弹出提示框
//content：输出内容
//url：跳转url
//title：标题
//fun：确定执行的方法
function Dialog(title, content, fun) {
    $("#xianshi1 .modal-title").text(title);
    $("#xianshi1 .modal-content").text(content);
    $("#xianshi1").show();

    $("#xianshi1 #btn_close").click(function () {
        $("#xianshi1").hide();
    })
    $("#xianshi1 #btnqueren").click(function () {
        fun();//执行方法
        $("#xianshi1").hide();//隐藏
    })
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



//JS导出EX-----------
//tableid 表格ID   sheetName导出表格名称
function tableToExcel(tableid, sheetName) {
    var uri = 'data:application/vnd.ms-excel;base64,';
    var template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel"' +
        'xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet>'
        + '<x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets>'
        + '</x:ExcelWorkbook></xml><![endif]-->' +
        ' <style type="text/css">' +
        'table td {' +
        'border: 1px solid #000000;' +
        'width: 200px;' +
        'height: 30px;' +
        ' text-align: center;' +
        'background-color: #4f891e;' +
        'color: #ffffff;' +
        ' }' +
        '</style>' +
        '</head><body ><table class="excelTable">{table}</table></body></html>';
    if (!tableid.nodeType) tableid = document.getElementById(tableid);
    var ctx = { worksheet: sheetName || 'Worksheet', table: tableid.innerHTML };
    window.location.href = uri + base64(format(template, ctx));
}
var base64 = function (s) {
    return window.btoa(unescape(encodeURIComponent(s)));
};
//替换table数据和worksheet名字
var format = function (s, c) {
    return s.replace(/{(\w+)}/g,
        function (m, p) {
            return c[p];
        });
}
//-------------------END



//===========================工具类函数============================
//只允许输入数字
function checkNumber(e) {
    var keynum = window.event ? e.keyCode : e.which;
    if ((48 <= keynum && keynum <= 57) || keynum == 8) {
        return true;
    } else {
        return false;
    }
}
//只允许输入小数
function checkForFloat(obj, e) {
    var isOK = false;
    var key = window.event ? e.keyCode : e.which;
    if ((key > 95 && key < 106) || //小键盘上的0到9  
        (key > 47 && key < 60) ||  //大键盘上的0到9  
        (key == 110 && obj.value.indexOf(".") < 0) || //小键盘上的.而且以前没有输入.  
        (key == 190 && obj.value.indexOf(".") < 0) || //大键盘上的.而且以前没有输入.  
         key == 8 || key == 9 || key == 46 || key == 37 || key == 39) {
        isOK = true;
    } else {
        if (window.event) { //IE
            e.returnValue = false;   //event.returnValue=false 效果相同.    
        } else { //Firefox 
            e.preventDefault();
        }
    }
    return isOK;
}
//检查短信字数
function checktxt(obj, txtId) {
    var txtCount = $(obj).val().length;
    if (txtCount < 1) {
        return false;
    }
    var smsLength = Math.ceil(txtCount / 62);
    $("#" + txtId).html("您已输入<b>" + txtCount + "</b>个字符，将以<b>" + smsLength + "</b>条短信扣取费用。");
}
//四舍五入函数
function ForDight(Dight, How) {
    Dight = Math.round(Dight * Math.pow(10, How)) / Math.pow(10, How);
    return Dight;
}
//写Cookie
function addCookie(objName, objValue, objHours) {
    var str = objName + "=" + escape(objValue);
    if (objHours > 0) {//为0时不设定过期时间，浏览器关闭时cookie自动消失
        var date = new Date();
        var ms = objHours * 3600 * 1000;
        date.setTime(date.getTime() + ms);
        str += "; expires=" + date.toGMTString();
    }
    document.cookie = str;
}

//读Cookie
function getCookie(objName) {//获取指定名称的cookie的值
    var arrStr = document.cookie.split("; ");
    for (var i = 0; i < arrStr.length; i++) {
        var temp = arrStr[i].split("=");
        if (temp[0] == objName) return unescape(temp[1]);
    }
    return "";
}
//===================END==============


//===========================日期处理============================
// week first date
/*  Parameters：
 *  date: {Date}日期类型
 *  format: {string}日期格式
 */
function fn_weekFirstDate(date, format) {
    if (!format) { format = "yyyy-MM-dd" };
    var now = date; //当前日期 
    var nowDayOfWeek = now.getDay(); //今天本周的第几天 
    var nowDay = now.getDate(); //当前日
    if (nowDayOfWeek == 0) { nowDayOfWeek = 7 };
    var nowMonth = now.getMonth(); //当前月 
    var nowYear = now.getYear(); //当前年 
    nowYear += (nowYear < 2000) ? 1900 : 0;
    var weekStartDate = new Date(nowYear, nowMonth, nowDay + 1 - nowDayOfWeek);
    return weekStartDate.formatDate(format);
}

// week last date
/*  Parameters：
 *  date: {Date}日期类型
 *  format: {string}日期格式
 */
function fn_weekLastDate(date, format) {
    if (!format) { format = "yyyy-MM-dd" };
    var now = date; //当前日期 
    var nowDayOfWeek = now.getDay(); //今天本周的第几天 
    var nowDay = now.getDate(); //当前日 
    if (nowDayOfWeek == 0) { nowDayOfWeek = 7 };
    var nowMonth = now.getMonth(); //当前月 
    var nowYear = now.getYear(); //当前年 
    nowYear += (nowYear < 2000) ? 1900 : 0;
    var weekEndDate = new Date(nowYear, nowMonth, nowDay + (6 + 1 - nowDayOfWeek));
    return weekEndDate.formatDate(format);
}

// add days
/*  Parameters：
 *  date: {Date}日期类型
 *  day:天数
 *  format: {string}日期格式
 */
function fn_addDays(date, day, format) {
    if (!format) { format = "yyyy-MM-dd" };
    var now = date;//时间
    now.setDate(now.getDate() + day);//设置天数 +1 天
    return now.formatDate(format);
}

// time cut
/*  Parameters：
 *  date: {Date}日期类型
 */
function fn_timeCut(date) {
    var publishTime = date / 1000,
        d_seconds,
        d_minutes,
        d_hours,
        d_days,
        timeNow = parseInt(new Date().getTime() / 1000),
        d,

        date = new Date(publishTime * 1000),
        Y = date.getFullYear(),
        M = date.getMonth() + 1,
        D = date.getDate(),
        H = date.getHours(),
        m = date.getMinutes(),
        s = date.getSeconds();
    //小于10的在前面补0
    if (M < 10) {
        M = '0' + M;
    }
    if (D < 10) {
        D = '0' + D;
    }
    if (H < 10) {
        H = '0' + H;
    }
    if (m < 10) {
        m = '0' + m;
    }
    if (s < 10) {
        s = '0' + s;
    }

    d = timeNow - publishTime;
    d_days = parseInt(d / 86400);
    d_hours = parseInt(d / 3600);
    d_minutes = parseInt(d / 60);
    d_seconds = parseInt(d);

    if (d_days > 0 && d_days < 7) {
        return d_days + '天前';
    } else if (d_days <= 0 && d_hours > 0) {
        return d_hours + '小时前';
    } else if (d_hours <= 0 && d_minutes > 0) {
        return d_minutes + '分钟前';
    } else if (d_seconds < 60) {
        if (d_seconds <= 0) {
            return '刚刚';
        } else {
            return d_seconds + '秒前';
        }
    } else if (d_days >= 7 && d_days < 30) {
        return M + '-' + D + ' ' + H + ':' + m;
    } else if (d_days >= 30) {
        return Y + '-' + M + '-' + D + ' ' + H + ':' + m;
    }
}

//format date
Date.prototype.formatDate = function (fmt) {
    if (!fmt) { fmt = "yyyy-MM-dd"; }
    var o = {
        "M+": this.getMonth() + 1, //月份   
        "d+": this.getDate(), //日   
        "h+": this.getHours(), //小时   
        "m+": this.getMinutes(), //分   
        "s+": this.getSeconds(), //秒   
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
        "S": this.getMilliseconds() //毫秒   
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length === 1) ? (o[k]) : (("00" + o[k]).substr(("" + o

        [k]).length)));
    return fmt;
}
//==========================END===================


//=======================JS Base64===================
///解密：
function atob(Object){
    window.atob(Object) 

}

///加密：
function btoa(Object) {
    window.btoa(Object)

}

///带中文解密
function atob(obj) {
    decodeURIComponent(window.atob(obj))
}
//=============END