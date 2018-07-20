
//微信扫一扫功能-------------------
//微信扫码配置
//date 数据wx.config配置{appId:"",timestamp:"",nonceStr:"",signature:""} JSON字符串
//debug 是否调试模式 默认false（不启用）
function wx_QeCode_config(date, debug) {
	if (typeof (debug) != "undefined" && debug != "") {
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
	if (typeof (debug) != "undefined" && debug != "") {
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
function  wx_chooseImage(count) {
	var serverIds;//定义返回结果
	if (typeof (count) != "undefined" && count != "") {
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
				serverIds += result+",";
			}
			return serverIds;
		}
	});
}
//返回图片的服务器端ID 
function uploadImage(localId) {
	wx.uploadImage({
		localId: localId, // 需要上传的图片的本地ID，由chooseImage接口获得
		isShowProgressTips: 1, // 默认为1，显示进度提示
		success: function (res) {
			var serverId = res.serverId; // 返回图片的服务器端ID 
			return serverId;
			//downloadImage(serverId);
		}
	});
}
//返回图片下载后的本地ID
function downloadImage(serverId) {
	wx.downloadImage({
		serverId: serverId, // 需要下载的图片的服务器端ID，由uploadImage接口获得
		isShowProgressTips: 1, // 默认为1，显示进度提示
		success: function (res) {
			var localId = res.localId; // 返回图片下载后的本地ID  
			return localId;
		}
	});
}
//-------------------END---------------


//支付方法-------------------------------------------
//调用支付方法
function wx_Tenpay(r) {
	return callpay(r);
}
//微信公众号支付
function jsApiCall(r) {
	WeixinJSBridge.invoke(
	 'getBrandWCPayRequest', r,
   function (res) {
   	// alert(res.err_code + res.err_desc);
   	// alert(res.err_msg);
   	if (res.err_msg == "get_brand_wcpay_request:ok") {
   		return true;//支付成功！
   	} else {
   		return false;//用户取消支付

   	}
   }
);
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
		jsApiCall(r);
	}
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
	if (typeof (debug) != "undefined" && debug != "") {
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