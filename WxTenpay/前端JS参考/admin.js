/*
 * 每个页面引用jquery，
 * layui.css，
 * layui.all.js，
*/
var Empty = [null, "", "null", undefined, "undefined"];
var ROOT_PATH = "/";
var iframeNames = [];

var $frame = {
    //上传文件请求formdata模式
    RequestPostformdata: function (url, data, yes, error) {
        let index = $frame.loading("正在提交数据，请稍候……");
        $.ajax({
            type: "post",
            url: ROOT_PATH + url,
            data: data,
            async: true,
            cache: false,//上传文件无需缓存
            processData: false,//用于对data参数进行序列化处理 这里必须false
            contentType: false, //必须
            success: function (res) {
                layer.close(index);
                if (yes) yes(res);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                layer.close(index);
                if (error) error(jqXHR, textStatus, errorThrown);
            }
        });
    },
    //post请求
    RequestPost: function (url, data, yes, error) {
        let index = $frame.loading("正在提交数据，请稍候……");
        $.ajax({
            type: "post",
            url: ROOT_PATH + url,
            data: data,
            success: function (res) {
                layer.close(index);
                if (yes)
                    yes(res);
            },
            error: function (res) {
                layer.close(index);
                if (error)
                    error(res);
            }
        });
    },
    //get请求
    RequestGet: function (url, data, yes, error) {
        let index = $frame.loading();
        $.ajax({
            type: "get",
            url: ROOT_PATH + url,
            data: data,
            success: function (res) {
                layer.close(index);
                if (yes)
                    yes(res);
            },
            error: function (res) {
                layer.close(index);
                if (error)
                    error(res);
            }
        });
    },
    //获取表单数据
    getFormData: function (formId) {
        var data = {};
        $('#' + formId).find('input[type=number],input[type=password],input[type=text],input[type=radio]:checked,input[type=hidden],input[type=date],select,textarea').each(function () {
            var elName = $(this).attr('name');
            var elValue = $(this).val();
            if (elName) {
                data[elName] = elValue;
            }

        });

        $('#' + formId).find('input[type=checkbox]:checked').each(function () {
            var elName = $(this).attr('name');
            var elValue = $(this).val();

            if (elName in data) {
                data[elName].push(elValue);
            }
            else {
                data[elName] = [elValue];
            }
        })
        return data;
    },
    //赋值表单数据
    SetFormData: function (data) {
        for (var id in data) {
            var value = data[id];
            var $obj = $('#' + id);
            if ($obj.length == 0 && value != null) {
                $obj = $('[name="' + id + '"][value="' + value + '"]');
                if ($obj.length > 0) {
                    if (!$obj.is(":checked")) {
                        $obj.trigger('click');
                    }
                }
            } else {
                var type = $obj.attr('type');
                switch (type) {
                    case "checkbox":
                        var isck = 0;
                        if ($obj.is(":checked")) {
                            isck = 1;
                        } else {
                            isck = 0;
                        }
                        if (isck != parseInt(value)) {
                            $obj.trigger('click');
                        }
                        break;
                    case "radio":
                        if (!$obj.find('input[value="' + value + '"]').is(":checked")) {
                            $obj.find('input[value="' + value + '"]').trigger('click');
                        }
                        break;
                    default:
                        $obj.val(value);
                        break;
                }
            }
        }
    },
    //提示框
    alert: function (content, btns, fun, fun2, fun3) {
        content = content || ["确定"];
        layer.open({
            offset: '80px',
            btnAlign: 'c',
            content: content
            , btn: btns
            , yes: function (index, layero) {
                if (fun)
                    fun();

                layer.close(index);
            }
            , btn2: function (index, layero) {
                if (fun2)
                    fun2();
                layer.close(index);
            }
            , btn3: function (index, layero) {
                if (fun3)
                    fun3();
                layer.close(index);
            }
            , cancel: function () {
                //右上角关闭回调

                //return false 开启该代码可禁止点击该按钮关闭
            }
        });
    },
    // 询问框
    confirm: function (msg, callback) {
        layer.confirm(msg, {
            btn: ['确认', '取消'],
            title: "提示",
            icon: 0,
            skin: 'demo-class',
        }, function (index) {
            callback(true, index);
            layer.close(index); //再执行关闭
        }, function (index) {
            callback(false, index);
            layer.close(index); //再执行关闭  
        });
    },
    // 自定义表单弹层
    layerForm: function (obj) {
        var dfop = {
            id: null,
            title: '信息',
            width: 550,
            height: 400,
            url: 'error',
            btn: ['确认', '关闭'],
            callBack: false,
            maxmin: false,
            end: false,
        };
        $.extend(dfop, obj || {});
        /*适应窗口大小*/
        dfop.width = dfop.width > $(window).width() ? $(window).width() - 10 : dfop.width;
        dfop.height = dfop.height > $(window).height() ? $(window).height() - 10 : dfop.height;
        var r = layer.open({
            id: dfop.id,
            maxmin: dfop.maxmin,
            type: 2,//0（信息框，默认）1（页面层）2（iframe层）3（加载层）4（tips层）
            title: dfop.title,
            area: [dfop.width + 'px', dfop.height + 'px'],
            btn: dfop.btn,
            content: dfop.url,
            skin: 'demo-class',
            success: function (layero, index) {
                //if ($frame.IsEmpty(iframeNames['iframe_' + dfop.id]))//为空保存对象
                //    iframeNames['iframe_' + dfop.id] = $frame.IsEmpty(iframeNames['iframe_' + dfop.id]) ? iframeNames['iframe_' + dfop.id] : iframeNames['iframe_' + dfop.id].contentWindow;//保存窗体对象
                //else {
                //    if (!$frame.IsEmpty(iframeNames['iframe_' + dfop.id].contentWindow))
                //        iframeNames['iframe_' + dfop.id] = iframeNames['iframe_' + dfop.id].contentWindow;
                //    else
                //        iframeNames['iframe_' + dfop.id] = iframeNames['iframe_' + dfop.id]
                //}
            },
            yes: function (index) {//确认
                var flag = true;
                if (!!dfop.callBack) {
                    flag = dfop.callBack('iframe_' + dfop.id);
                }
                if (!!flag) {
                    layer.close('',index);
                }
            },
            end: function () {//关闭
                iframeNames['iframe_' + dfop.id] = null;
                if (!!dfop.end) {
                    dfop.end();
                }
            }
        });
    },
    //加载框
    loading: function (msg) {
        msg = msg || "正在读取数据，请稍候……";
        return layer.msg(msg, { icon: 16, shade: 0.01, shadeClose: false, time: 60000 });
    },
    //提示
    alert_msg: function (content) {
        content = content || "操作成功！";
        return layer.msg(content);
    },
    //获取url参数
    GetQueryString: function (name) {
        var reg = new RegExp('(^|&)' + name + '=([^&]*)(&|$)', 'i');
        var r = window.location.search.substr(1).match(reg);
        if (r != null) {
            return unescape(r[2]);
        }
        return null;
    },
    //=================对象数组分组==========
    //用法  
    //const sorted = this.groupBy(data, function (item) {
    //       return [item.key];
    //  });
    groupBy: function (array, f) {
        const groups = {};
        array.forEach(function (o) {
            const group = JSON.stringify(f(o));
            groups[group] = groups[group] || [];
            groups[group].push(o);
        });
        return Object.keys(groups).map(function (group) {
            return groups[group];
        });
    },
    //数据筛查data:数据源，keys:查询key values:key的值,fuzzy:是否模糊查询 true 启用  false完全匹配
    /*用法 模糊查询默认不启用
     * filter(data,["age","name","sex"],[20,"1111",0],[false,true,false])
     * filter(data,["age","name","sex"],[20,"1111",0],[false,true])
     * filter(data,["age","name","sex"],[20,"1111",0])
     * filter(data,"name","1111",true)
     * filter(data,"name","1111")
     */
    filter: function (data, keys, values, fuzzy) {
        //let index =  $frame.loading("数据处理中...");
        let newdata = [];
        let lisnewdata = [];
        if (typeof keys == "object") {
            fuzzy = fuzzy || [false];
            lisnewdata[1] = [];
            for (var index in keys) {
                if (index == "0") {
                    for (var itm in data) {
                        if (fuzzy[index] && typeof data[itm][keys[index]] == "string") {
                            if (data[itm][keys[index]].indexOf(values[index]) > -1) { //1
                                lisnewdata[(parseInt(index) + 1)].push(data[itm]);
                            }
                        } else {
                            if (data[itm][keys[index]] == values[index]) { //1
                                lisnewdata[(parseInt(index) + 1)].push(data[itm]);
                            }
                        }
                    }
                } else {
                    lisnewdata[(parseInt(index) + 1)] = [];
                    for (var itm in lisnewdata[index]) {
                        if (fuzzy[index] && typeof lisnewdata[index][itm][keys[index]] == "string") {
                            if (lisnewdata[index][itm][keys[index]].indexOf(values[index]) > -1) { //2
                                lisnewdata[(parseInt(index) + 1)].push(lisnewdata[index][itm]);
                            }
                        } else {
                            if (lisnewdata[index][itm][keys[index]] == values[index]) { //2
                                lisnewdata[(parseInt(index) + 1)].push(lisnewdata[index][itm]);
                            }
                        }
                    }
                    if (keys.length == (parseInt(index) + 1))
                        newdata = lisnewdata[(parseInt(index) + 1)];
                }
            }
            //newdata = lis;
        } else {
            for (var itm in data) {
                if (fuzzy) {
                    if (data[itm][keys].indexOf(values) > -1)
                        newdata.push(data[itm]);
                } else {
                    if (data[itm][keys] == values)
                        newdata.push(data[itm]);
                }
            }
        }
        //layer.close(index);
        return newdata;
    },

    //数据排序
    //_sort true 正序  false 倒序
    sorting: function (data, key, _sort) {
        function keysrt(key) {
            return function (object1, object2) {
                var val1 = object1[key];
                var val2 = object2[key];
                if (val1 < val2) {
                    return -1;
                } else if (val1 > val2) {
                    return 1;
                } else {
                    return 0;
                }
            }
        }
        let newdata = [];
        switch (typeof data[0][key]) {
            case "string":
                if (_sort)
                    newdata = data.reverse(keysrt(key));
                else
                    newdata = data.sort(keysrt(key))

                break;
            case "number":
                if (_sort) {
                    newdata = data.sort(function (a, b) {
                        return a[key] - b[key];
                    })
                } else {
                    newdata = data.sort(function (a, b) {
                        return b[key] - a[key];
                    })
                }
                break;
        }

        return newdata;
    },
    //时间类型
    fn_weekFirstDate: function (date, format) {
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
    },
    fn_weekLastDate: function (date, format) {
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
    },
    fn_addDays: function (date, day, format) {
        if (!format) { format = "yyyy-MM-dd" };
        var now = date;//时间
        now.setDate(now.getDate() + day);//设置天数 +1 天
        return now.formatDate(format);
    },
    fn_timeCut: function (date) {
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
    },
    ///----end

    //判断日期类型是否为YYYY-MM-DD格式的类型    
    IsDate: function (str) {
        if (str.length != 0) {
            let reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/;
            let r = str.match(reg);
            if (r == null)
                return false;
            else
                return true;
        }
        return false;
    },
    //判断日期类型是否为YYYY-MM-DD hh:mm:ss格式的类型    
    IsDateTime: function (str) {
        if (str.length != 0) {
            let reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/;
            let r = str.match(reg);
            if (r == null) return false; else return true
        }
        return false
    },
    //判断输入的字符是否为英文字母    
    IsLetter: function (str) {
        if (str.length != 0) {
            let reg = /^[a-zA-Z]+$/;
            if (!reg.test(str)) return fasle; else return true;
        }
        return false;
    },
    //判断输入的字符是否为整数    
    IsInteger: function (str) {
        if (str.length != 0) {
            let reg = /^[-+]?\d*$/;
            if (!reg.test(str)) return false; else return true;
        }
        return false;
    },
    //判断输入的字符是否为双精度    
    IsDouble: function (str) {
        if (str.length != 0) {
            let reg = /^[-\+]?\d+(\.\d+)?$/;
            if (!reg.test(str)) return false; else return true;

        }
        return false;
    },
    //判断输入的字符是否为:a-z,A-Z,0-9    
    IsString: function (str) {
        if (str.length != 0) {
            let reg = /^[a-zA-Z0-9_]+$/;
            if (!reg.test(str)) return false; else return true;

        }
        return false;
    },
    //判断输入的字符是否为中文    
    IsChinese: function (str) {
        if (str.length != 0) {
            let reg = /^[\u0391-\uFFE5]+$/;
            if (!reg.test(str)) return false; else return true;
        }
        return false;
    },
    //判断身份证
    isIDCard: function (str) {
        if (str.length != 0) {
            let reg = /^\d{15}(\d{2}[A-Za-z0-9;])?$/;
            if (!reg.test(str)) return false; else return true;
        }
        return false;
    },
    //判断输入的EMAIL格式是否正确    
    IsEmail: function (str) {
        if (str.length != 0) {
            let reg = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
            if (!reg.test(str)) return false; else return true;
        }
        return false;
    },
    //判断输入的邮编(只能为六位)是否正确    
    IsZIP: function (str) {
        if (str.length != 0) {
            let reg = /^\d{6}$/;
            if (!reg.test(str)) return false; else return true;
        }
        return false;
    },
    //只允许输入数字
    checkNumber: function (e) {
        var keynum = window.event ? e.keyCode : e.which;
        if ((48 <= keynum && keynum <= 57) || keynum == 8) {
            return true;
        } else {
            return false;
        }
    },
    //只允许输入小数
    checkForFloat: function (obj, e) {
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
    },
    //检查邮箱
    checkEmail: function (obj) {
        let reyx = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/;
        return (reyx.test(obj));

    },
    //验证是否有字母
    checkreg: function (obj) {
        let regString = /[a-zA-Z]+/;
        return (regString.test(obj));
    },
    //四舍五入函数
    ForDight: function (Dight, How) {
        Dight = Math.round(Dight * Math.pow(10, How)) / Math.pow(10, How);
        return Dight;
    },
    //非空判断
    IsEmpty: function (str) {
        //true  空
        return Empty.includes(str);
    },
    //是否手机号码
    IsPhone: function (str) {
        let phoneNumReg = /(^[0-9]{3,4}\-[0-9]{7}$)|(^[0-9]{7}$)|(^[0-9]{3,4}[0-9]{7}$)|(^0{0,1}13[0-9]{9}$)/
        return phoneNumReg.test(str);

    },
    ///base解密：
    decode: function (str) {
        return window.atob(str)
    },
    ///base加密：
    encrypt: function (str) {
        return window.btoa(str)
    },
    ///带中文解密
    decodeatob: function (str) {
        return decodeURIComponent(window.atob(str))
    },
    //缓存保存
    Storageset: function (key, value) {
        window.localStorage.setItem(key, JSON.stringify(value));
    },
    //缓存获取
    Storageget: function (key) {
        return JSON.parse(window.localStorage.getItem(key));
    },
    //缓存移除
    StorageRemove: function (key) {
        window.localStorage.removeItem(key);
    },
    //临时缓存保存
    sessionset: function (key, value) {
        window.sessionStorage.setItem(key, JSON.stringify(value));
    },
    //临时缓存获取
    sessionget: function (key) {
        return JSON.parse(window.sessionStorage.getItem(key));
    },
    //临时缓存移除
    sessionRemove: function (key) {
        window.sessionStorage.removeItem(key);
    },
    //打开url
    openurl: function (str) {
        window.open(str);
    },
    //导出网页excel
    tableToExcel: function (tableid, sheetName, backgroundcolor) {
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
    },



}


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



