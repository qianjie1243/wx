 # 快速了解 微信公众号开发c#

 一. ** 项目介绍
这个微信功能类，目前还未全部完善，还有一部分功能，暂时未进行测试，关于微信公众号支付中body中文，出现签名失败的问题，可以对body进行UTF-8处理，已进行完成，没有中文可以把body中的转换格式注释掉，保证正常使用，关于微信红包功能，已测试（win系统，在服务器上安装证书，在wxconfig中配置证书路径即可），可以使用。目前针对文档暂未完善。可以下载，参考，对功能自己进行完善，封装，加密等处理。（目前未对基本配置参数做配置文件中处理。），集成了阿里云短信，支付宝支付部分功能，百度AI部分接口，百度AI后期会全部完善


# 项目结构
> * WxTenpay 解决方案
>> BLL  数据库操作
>> AliYun 阿里服务类
>> BaiDuAi 百度AI服务类
>> Common  公共操作类
>> Redis   缓存类（包含安装文件，word）
>> webfront HTML页面端
>> wxtenpay 微信公众号基本操作功能类（如果需要单独运行，需要在web或者在bin添加WxTenPay.config配置文件，目前在项目webfront中已有配置文件）

# 当前版本分为数据库版本与非数据库版本
### 一. 数据库版本路劲为 WebFront/v1.1
### 二. 非数据库版本路劲为 WebFront/html

# 功能展示图

### 新增功能模块：![输入图片说明](https://images.gitee.com/uploads/images/2020/0730/155209_78287df9_1689037.png "屏幕截图.png")
### 新增页面功能：

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
后期待完善功能