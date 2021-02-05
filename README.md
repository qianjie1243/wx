 # 微信公众号开发c#
# 下载项目》运行项目出现异常》点击加载全部文件，
出现没有包含在项目中的文件请包含在项目中.包含bin 
楼主QQ369841603
有疑问请加好友 #

 一. ** 项目介绍
这个微信功能类，目前还未全部完善，还有一部分功能，暂时未进行测试，关于微信公众号支付中body中文，出现签名失败的问题，可以对body进行UTF-8处理，已进行完成，没有中文可以把body中的转换格式注释掉，保证正常使用，关于微信红包功能，已测试（win系统，在服务器上安装证书，在wxconfig中配置证书路径即可），可以使用。目前针对文档暂未完善。可以下载，参考，对功能自己进行完善，封装，加密等处理。（目前未对基本配置参数做配置文件中处理。），集成了阿里云短信，支付宝支付部分功能，百度AI部分接口，百度AI后期会全部完善


# 项目结构
### WxTenpay 解决方案
> * BLL  数据库操作
> * AliYun 阿里服务类
> * BaiDuAi 百度AI服务类
> * Common  公共操作类
> * Redis   缓存类（包含安装文件，word）
> * webfront HTML页面端
> * wxtenpay 微信公众号基本操作功能类（如果需要单独运行，需要在web或者在bin添加WxTenPay.config配置文件，目前在项目webfront中已有配置文件）
### 数据库
> * DB.sql
> * DB.bak


# WxTenpay 操作类型说明
####  Wechat_Menu 类
> * graphic 说明：上传图文素材
> * material  说明：上传图片,语音，缩略图
> * video  说明：  视频上传到微信公众号
> * Update_graphic  说明：修改素材
> * Get_list   说明：获取素材列表
> * Get_count  说明：获取素材总数
> * Get_graphic   说明：获取永久素材
> * Del_graphic  说明：获取永久素材
> * Menu   说明：自定义菜单
> * Getuserlis 说明：获取关注用户数量
> * CreateLabel 说明:创建用户标签
> * GetLabels  说明：获取公众号已创建的标签
> * UpdateLabel  说明：编辑公众号已创建的标签
> * DeleteLabel  说明：删除公众号已创建的标签
> * GetLabelUsers  说明：获取标签下粉丝列表
> * CreateUserLabel  说明：批量为用户打标签
> * DeteteUserLabel  说明：批量为用户取消标签
> * GetUserLabels  说明：获取用户身上的标签列表
#### WechatPublic 类
> * GetPersonal  说明：code获取个人信息
> * GetOpenid  说明：code返回openid
> * GetWxConfig  说明： 获取前端JS所需WX.config
> * GetToken  说明： 获取access_token
> * GetTokenTime  说明： 获取access_token获取时间
> * EmptyToken  说明： 清空Token、jsapi_ticket
> * GetJsapi_ticket  说明： 获取Asscess,jsapi_ticket
> * GetJsapiTicketTime  说明： 获取jsapi_ticket获取时间
> * WeiXinKeFu  说明： 微信客户消息
> * WeiXinTemplate  说明： 发送微信模板消息
#### WeChatPayment 类
> * NATIVEPayMent  说明： 微信扫码支付
> * APP_PayMent  说明： 微信APP支付
> * JSAPIPayMent 说明： 微信公众号支付
> * GetPayMent_result 说明： 查询扫码订单情况，公众号支付订单状态查询、页面端 微信支付状态:OK有可能存在风险，建议使用订单号去查看订单状态,
> * PayMent_result 说明： 获取支付订单状态（微信回调）
> * Inform 说明： 通知微信已收到XML回调通知

# 当前版本分为数据库版本与非数据库版本
### 一. 数据库版本路劲为 WebFront/v1.1
### 二. 非数据库版本路劲为 WebFront/html

# 使用相关技术
> * sqlsugar （数据库orm）相关文档地址 http://www.donet5.com/
> * redis （缓存技术）相关文档地址 https://redis.io/
> * Layui （前端框架）相关文档地址 https://www.layui.com/ 
> * Vue.js （前端框架）相关文档地址 https://vuejs.org/

# 前端 admin.js 为自行根据layui封装公共操作js
> * 请求 post、get、formdatapost
> * 数据基本验证
> * 数据库分页、页面分页
> * 弹窗
> * 提示
> * 页面存储
> * 下载表格（excel）
> * 下载word
> * ...

# 下次更新内容（本人业余时间开发进度比较缓慢、随性而为 ）
> * 提供手机端公众号测试页面 使用框架（vant.js）
> * ...
> * ...


# 后台测试地址  http://111.231.15.185
# 微信公众号功能测试地址 http://111.231.15.185/v1.1_Mobile/index.html
微信测试号![输入图片说明](https://images.gitee.com/uploads/images/2021/0111/214710_2ac87124_1689037.png "屏幕截图.png")

# 功能展示图

![输入图片说明](https://images.gitee.com/uploads/images/2020/0730/155209_78287df9_1689037.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2020/0730/155108_58f901bd_1689037.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2020/0731/145140_a486a0b3_1689037.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2020/0802/171137_a8a7915e_1689037.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2020/0809/142817_a241e124_1689037.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2020/0809/142853_832aa2a7_1689037.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2020/0812/153550_0b6942b7_1689037.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2020/0812/153637_0a6d4eaf_1689037.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2020/0816/135322_125aef98_1689037.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2020/0816/122435_7b505175_1689037.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2020/0816/122755_fb629b76_1689037.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2020/0816/122824_a45dd410_1689037.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2020/0816/154255_4f147938_1689037.png "屏幕截图.png")
![微信url配置路径](https://images.gitee.com/uploads/images/2020/0822/180457_0804f53d_1689037.png "屏幕截图.png")
![测试扫码按钮事件、地理位置事件](https://images.gitee.com/uploads/images/2020/0822/180603_414fecee_1689037.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2020/0822/180810_5e637fcc_1689037.png "屏幕截图.png")
![按钮事件配置](https://images.gitee.com/uploads/images/2020/0822/180910_741782fb_1689037.png "屏幕截图.png")
![菜单配置](https://images.gitee.com/uploads/images/2020/0822/180937_2a2e11fc_1689037.png "屏幕截图.png")
![系统菜单管理](https://images.gitee.com/uploads/images/2020/1003/175759_1cb6ce48_1689037.png "屏幕截图.png")
![系统日志](https://images.gitee.com/uploads/images/2020/1003/175853_f0d04cc9_1689037.png "屏幕截图.png")
![数据库配置](https://images.gitee.com/uploads/images/2020/1003/175949_3d6ddaa2_1689037.png "屏幕截图.png")
![数据库文件](https://images.gitee.com/uploads/images/2020/1003/180022_1fc4527f_1689037.png "屏幕截图.png")
![数据库地址](https://images.gitee.com/uploads/images/2020/1014/180518_b03b212c_1689037.png "屏幕截图.png")
![添加数据库 生成实体](https://images.gitee.com/uploads/images/2020/1221/172824_6633484c_1689037.png "屏幕截图.png")
后期待完善功能- 这里是列表文本