
//全局微信JS引用
document.write("<script src='http://res.wx.qq.com/open/js/jweixin-1.2.0.js'></script>");

//微信扫一扫功能-------------------
//微信扫码配置
//date 数据wx.config配置{appId:"",timestamp:"",nonceStr:"",signature:""} JSON字符串
//debug 是否调试模式 默认false（不启用）
function wx_QeCode_config(date, debug) {
    if (typeof (debug) == "undefined" || debug == "") {
        debug = false;
    }
    var da1 = $.parseJSON(date);
    wx.config({
        debug: debug, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
        appId: da1.appId, // 必填，公众号的唯一标识
        timestamp: da1.timeStamp, // 必填，生成签名的时间戳
        nonceStr: da1.nonceStr, // 必填，生成签名的随机串
        signature: da1.signature,// 必填，签名，见附录1
        jsApiList: ["scanQRCode", "checkJsApi"] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
    });
    wx.error(function (res) {
        alert("wx.config failed.");
        //alert(res);
        // config信息验证失败会执行error函数，如签名过期导致验证失败，具体错误信息可以打开config的debug模式查看，
        // 也可以在返回的res参数中查看，对于SPA可以在这里更新签名。
    });
}
//微信扫一扫
function wx_QeCode() {
    wx.scanQRCode({
        needResult: 1,
        desc: 'scanQRCode desc',
        success: function (res) {
            //扫到的参数
            return res.resultStr;
        }
    });
}
//-----------------------------END----------------------------

//微信上传图片功能----------------------------------
//微信上传图片配置
//date 数据wx.config配置{appId:"",timestamp:"",nonceStr:"",signature:""} JSON字符串
//debug 是否调试模式 默认false（不启用）
function wx_chooseImage_config(date, debug) {
    if (typeof (debug) == "undefined" || debug == "") {
        debug = false;
    }
    var da1 = $.parseJSON(date);
    wx.config({
        debug: debug, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
        appId: da1.appId, // 必填，公众号的唯一标识
        timestamp: da1.timeStamp, // 必填，生成签名的时间戳
        nonceStr: da1.nonceStr, // 必填，生成签名的随机串
        signature: da1.signature,// 必填，签名，见附录1
        jsApiList: ["chooseImage", "uploadImage", "downloadImage"] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
    });
    wx.error(function (res) {
        alert("wx.config failed.");
        //alert(res);
        // config信息验证失败会执行error函数，如签名过期导致验证失败，具体错误信息可以打开config的debug模式查看，
        // 也可以在返回的res参数中查看，对于SPA可以在这里更新签名。
    });
}
//上传图片wx_chooseImage
//count 上传图片的张数 默认1张
//返回全部选中图片serverId  多个以,分割
function wx_chooseImage(count) {
    var serverIds = [];//定义返回结果
    if (typeof (count) == "undefined" && count == "") {
        count = 1;
    }
    wx.chooseImage({
        count: count, // 默认1
        sizeType: ['original', 'compressed'], // 可以指定是原图还是压缩图，默认二者都有
        sourceType: ['album', 'camera'], // 可以指定来源是相册还是相机，默认二者都有
        success: function (res) {
            var localIds = res.localIds; // 返回选定照片的本地ID列表，localId可以作为img标签的src属性显示图片         
            for (var i = 0; i < localIds.length; i++) {
                var result = uploadImage(localIds[i]);
             
                serverIds.push(result);
            }
        }
    });
    return serverIds;
}
//返回图片的服务器端ID 
function uploadImage(localId) {
    var serverId = "";
    wx.uploadImage({
        localId: localId, // 需要上传的图片的本地ID，由chooseImage接口获得
        isShowProgressTips: 1, // 默认为1，显示进度提示
        success: function (res) {
            serverId = res.serverId; // 返回图片的服务器端ID 	
        }
    });
    return serverId;
}

//返回图片下载后的本地ID
function downloadImage(serverId) {
    var localId = "";
    wx.downloadImage({
        serverId: serverId, // 需要下载的图片的服务器端ID，由uploadImage接口获得
        isShowProgressTips: 1, // 默认为1，显示进度提示
        success: function (res) {
            localId = res.localId; // 返回图片下载后的本地ID 		
        }
    });
    return localId;
}

//获取本地图片接口
function getLocalImgData(localId) {
    var localData = "";
    wx.getLocalImgData({
        localId: '', // 图片的localID
        success: function (res) {
            localData = res.localData; // localData是图片的base64数据，可以用img标签显示
        }
    });
    return localData;
}
//-------------------END---------------

//支付方法一   -------------------------------------------
//调用支付方法
function wx_Tenpay(r) {
    return callpay(r);
}
//微信公众号支付
function jsApiCall(r) {
    var result = false;
    WeixinJSBridge.invoke(
        'getBrandWCPayRequest', r,
        function (res) {
            // alert(res.err_code + res.err_desc);
            // alert(res.err_msg);
            if (res.err_msg == "get_brand_wcpay_request:ok") {
                result = true;//支付成功！
            } else {
                result = false;//用户取消支付
            }
        }
    );
    return result;
}

function callpay(r) {
    if (typeof WeixinJSBridge == "undefined") {
        if (document.addEventListener) {
            document.addEventListener('WeixinJSBridgeReady', jsApiCall, false);
        } else if (document.attachEvent) {
            document.attachEvent('WeixinJSBridgeReady', jsApiCall);
            document.attachEvent('onWeixinJSBridgeReady', jsApiCall);
        }
    } else {
        return jsApiCall(r);
    }
}




//支付方法二-------------------------------------------
//调用支付方法
function chooseWXPay(r) {
    var result = false;
    wx.chooseWXPay({
        r, // 支付签名
        success: function (res) {
            result = true;
        }
    });
    return result;
}
//-----------------END-------------------------------------

//------------------分享功能---------------------
//微信分享功能
//date 数据wx.config配置{appId:"",timestamp:"",nonceStr:"",signature:""} JSON字符串
//debug 是否调试模式 默认false（不启用）
//title 分享标题
//link 分享链接
//imgUrl 分享图标
//desc 分享描述
function wx_onMenuShareTimeline_config(date, debug, title, link, imgUrl, desc) {
    if (typeof (debug) == "undefined" || debug == "") {
        debug = false;
    }
    var da1 = $.parseJSON(date);
    wx.config({
        debug: debug, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
        appId: da1.appId, // 必填，公众号的唯一标识
        timestamp: da1.timeStamp, // 必填，生成签名的时间戳
        nonceStr: da1.nonceStr, // 必填，生成签名的随机串
        signature: da1.signature,// 必填，签名，见附录1
        jsApiList: ["onMenuShareTimeline", "onMenuShareQZone", "onMenuShareAppMessage"] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
    });
    wx.ready(function () {
        //获取“分享到朋友圈”按钮点击状态及自定义分享内容接口
        wx.onMenuShareTimeline({
            title: title, // 分享标题
            link: link, // 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
            imgUrl: imgUrl, // 分享图标
            success: function () {
                alert("分享成功！");
                // 用户确认分享后执行的回调函数
            },
            cancel: function () {
                alert("您取消了分享");
                // 用户取消分享后执行的回调函数
            }
        });
        //获取“分享到QQ空间”按钮点击状态及自定义分享内容接口
        wx.onMenuShareQZone({
            title: title, // 分享标题
            desc: desc, // 分享描述
            link: link, // 分享链接
            imgUrl: imgUrl, // 分享图标
            success: function () {
                alert("分享成功！");
                // 用户确认分享后执行的回调函数
            },
            cancel: function () {
                alert("您取消了分享");
                // 用户取消分享后执行的回调函数
            }
        });
        //获取“分享给朋友”按钮点击状态及自定义分享内容接口
        wx.onMenuShareAppMessage({
            title: title, // 分享标题
            desc: desc, // 分享描述
            link: link, // 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
            imgUrl: imgUrl, // 分享图标
            type: '', // 分享类型,music、video或link，不填默认为link
            dataUrl: '', // 如果type是music或video，则要提供数据链接，默认为空
            success: function () {
                alert("分享成功！");
                // 用户确认分享后执行的回调函数
            },
            cancel: function () {
                alert("您取消了分享");
                // 用户取消分享后执行的回调函数
            }
        });
    });
    wx.error(function (res) {
        alert("wx.config failed.");
        alert(res);
        // config信息验证失败会执行error函数，如签名过期导致验证失败，具体错误信息可以打开config的debug模式查看，
        // 也可以在返回的res参数中查看，对于SPA可以在这里更新签名。
    });
}
//--------------------------END------------------------



//---------------微信获取地理位置接口------------------
//date 数据wx.config配置{appId:"",timestamp:"",nonceStr:"",signature:""} JSON字符串
//debug 是否调试模式 默认false（不启用）
function LocationWxconfig(data, debug) {
    if (typeof (debug) == "undefined" || debug == "") {
        debug = false;
    }
    var dal = $.parseJSON(data);
    wx.config({
        debug: debug, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
        appId: da1.appId, // 必填，公众号的唯一标识
        timestamp: da1.timeStamp, // 必填，生成签名的时间戳
        nonceStr: da1.nonceStr, // 必填，生成签名的随机串
        signature: da1.signature,// 必填，签名，见附录1
        jsApiList: ["openLocation", "getLocation",] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
    });
    wx.ready(function () {
        //页面加载事件
    });
    wx.error(function (res) {
        alert(res);
        // config信息验证失败会执行error函数，如签名过期导致验证失败，具体错误信息可以打开config的debug模式查看，
        // 也可以在返回的res参数中查看，对于SPA可以在这里更新签名。
    });
}


//打开微信腾讯地图
//longitude,纬度，浮点数，范围为90 ~ -90
//latitude 经度，浮点数，范围为180 ~ -180。
//name  位置名
//address  地址详情说明
//scale 地图缩放级别,整形值,范围从1~28。默认为最大
//infoUrl:  // 在查看位置界面底部显示的超链接,可点击跳转
function openLocation(longitude, latitude, name, address, scale) {
    wx.openLocation({
        latitude: latitude,
        longitude: longitude,
        name: name,
        address: address,
        scale: scale,
        infoUrl: 'http://weixin.<a href="http://www.it165.net/qq/" target="_blank" class="keylink">qq</a>.com'
    });
}

//获取地理位置
function getLocation() {
    wx.getLocation({
        type: 'wgs84', // 默认为wgs84的gps坐标，如果要返回直接给openLocation用的火星坐标，可传入'gcj02'  
        success: function (res) {
            res.latitude; // 纬度，浮点数，范围为90 ~ -90  
            res.longitude; // 经度，浮点数，范围为180 ~ -180。  
            res.speed;// 速度，以米/每秒计
            res.accuracy; // 位置精度
        },
        cancel: function (res) {
            alert('用户拒绝授权获取地理位置');
        }
    });
}

//---------------END-----------------------


//微信语音接口SDK
//date 数据wx.config配置{appId:"",timestamp:"",nonceStr:"",signature:""} JSON字符串
//debug 是否调试模式 默认false（不启用）
function VoiceWxconfig(data, debug) {
    if (typeof (debug) == "undefined" || debug == "") {
        debug = false;
    }
    var dal = $.parseJSON(data);
    wx.config({
        debug: debug, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
        appId: da1.appId, // 必填，公众号的唯一标识
        timestamp: da1.timeStamp, // 必填，生成签名的时间戳
        nonceStr: da1.nonceStr, // 必填，生成签名的随机串
        signature: da1.signature,// 必填，签名，见附录1
        jsApiList: ["translateVoice", "startRecord", "playVoice", "pauseVoice", "stopVoice", "onVoicePlayEnd", "stopRecord", "onVoiceRecordEnd", "uploadVoice", "downloadVoice"] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
    });
    wx.ready(function () {
        onVoicePlayEnd();//监听语音播放完毕接口
        onVoiceRecordEnd(); //监听录音自动停止接口
        //页面加载事件
    });
    wx.error(function (res) {
        alert(res);
        // config信息验证失败会执行error函数，如签名过期导致验证失败，具体错误信息可以打开config的debug模式查看，
        // 也可以在返回的res参数中查看，对于SPA可以在这里更新签名。
    });
}

//----------------开始录音------------
function startRecord() {
    wx.startRecord();
}
//--------------END------------

//----------------停止录音-------------
function stopRecord() {
    var localId;
    wx.stopRecord({
        success: function (res) {
            var localId = res.localId;
        },
        fail: function (res) {
            alert(JSON.stringify(res));
        }
    });
    return localId;
}
//--------------END--------------

//--监听录音自动停止接口--------------
function onVoiceRecordEnd() {
    var localId;
    wx.onVoiceRecordEnd({
        // 录音时间超过一分钟没有停止的时候会执行 complete 回调
        complete: function (res) {
            localId = res.localId;
        },
        fail: function (res) {
            alert(JSON.stringify(res));
        }
    });
    return localId
}
//------------END--------------------

//--------播放语音接口--------------
function playVoice(localId) {
    wx.playVoice({
        localId: localId // 需要播放的音频的本地ID，由stopRecord接口获得
    });
}
//--------------END---------------------

//--------暂停播放接口---------------
function pauseVoice(localId) {
    wx.pauseVoice({
        localId: localId // 需要暂停的音频的本地ID，由stopRecord接口获得
    });
}
//----------------END-------------

//--------停止播放接口---------------
function stopVoice(localId) {
    wx.stopVoice({
        localId: localId // 需要停止的音频的本地ID，由stopRecord接口获得
    });
}
//----------------END-------------

//-------------上传音频
function uploadVoice(localId) {
    var serverId;
    wx.uploadVoice({
        localId: localId, // 需要上传的音频的本地ID，由stopRecord接口获得
        isShowProgressTips: 1, // 默认为1，显示进度提示
        success: function (res) {
            serverId = res.serverId; // 返回音频的服务器端ID
        },
        fail: function (res) {
            alert(JSON.stringify(res));
        }
    });
    return serverId;
}
//----------------END------------

//-------------下载音频
function downloadVoice(serverId) {
    var localId;
    wx.downloadVoice({
        serverId: serverId, // 需要下载的音频的服务器端ID，由uploadVoice接口获得
        isShowProgressTips: 1, // 默认为1，显示进度提示
        success: function (res) {
            localId = res.localId; // 返回音频的本地ID
        },
        fail: function (res) {
            alert(JSON.stringify(res));
        }
    });
    return localId;
}
//----------------END------------

//监听语音播放完毕接口--注册微信播放录音结束事件【一定要放在wx.ready函数内】
function onVoicePlayEnd() {
    var localId;
    wx.onVoicePlayEnd({
        success: function (res) {
            var localId = res.localId; // 返回音频的本地ID
        },
        fail: function (res) {
            alert(JSON.stringify(res));
        }
    });
    return localId;
}
//--------------END-------------

//音频转文字接口
function translateVoice(localId) {
    var result;
    wx.translateVoice({
        localId: localId, // 需要识别的音频的本地Id，由录音相关接口获得
        isShowProgressTips: 1, // 默认为1，显示进度提示
        success: function (res) {
            result = res.translateResult; // 语音识别的结果
        },
        fail: function (res) {
            alert(JSON.stringify(res));
        }
    });
    return result;
}
//----------END-----------------


//jquery绑定touchstart 与touchend 事件(用于手机端按住和松开事件)
//var recordTimer;
    //touchstart   手机端按住事件
// $(id).on("touchstart",function(event){
//   event.preventDefault(); 防止其他事件发生，如href，表单提交
// recordTimer = setTimeout(function() {
//wstartRecord()
//}, 300);
//})
//touchend   手机端松开事件
// $(id).on("touchend",function(event){
//  event.preventDefault(); 防止其他事件发生，如href，表单提交
// clearTimeout(recordTimer);
//})
//--------------------END-----------------------

//-------------------END----------------------------------