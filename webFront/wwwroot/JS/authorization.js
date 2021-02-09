
$(function () {
    if (!top.parent_obj) {//页面单独打开跳转登入页面
        window.location.href = "../Login.html";
        return false;
    } else {
        let o = top.parent_obj.getopeniframename();//获取当前授权对象
        let btns = $('[authorization="yes"]').find('button');
        $.each(btns, (i, v) => {
            if (o.authorizationbtns.filter((e) => { return e.Number == $(v).prop("id") }).length > 0) {
                //显示按钮事件
            } else
                $(v).remove();//移除按钮事件
        });
    }
})

