

//浏览器定义存储
var Storage = {
    set(key, value) {
        window.localStorage.setItem(key, JSON.stringify(value));
    },
    get(key) {
        return JSON.parse(window.localStorage.getItem(key));
    },
    Remove(key) {
        window.localStorage.removeItem(key);
    }
};



//浏览器临时存储
var TemporaryStorage = {
    set(key, value) {
        window.sessionStorage.setItem(key, JSON.stringify(value));
    },
    get(key) {
        return JSON.parse(window.sessionStorage.getItem(key));
    },
    Remove(key) {
        window.sessionStorage.removeItem(key);
    }
};


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