Every Day + 1
=================

##About US
####Team：[@Reversion](https://github.com/Reversion) （逆转） 目的，力求创新!
[![image]](Reversion https://github.com/Reversion)  
[image]: https://secure.gravatar.com/avatar/07248c0b131ff07a5cd636707aed6f4d?s=120&d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-org-120.png

=================

描述：日志记录类小清新网站，图文和音乐 （音乐采用虾米接口）
      采用新浪微博，腾讯QQ，豆瓣 第三方接口登陆注册  
          
      目前项目开发板块划分为
      首页| 最热话题-人气文章
      以时间轴 或 花瓣式UI呈现   
      PS,  获取 用户id ， 用后头像， 用户昵称，用户发表的被公开的文章 即文章信息
      小组| 同爱好，兴趣,地域，等有所公共部分交际的人群小组     
      历史| 设定一段时间内，在所有用户中陪 喜欢,转载，人数最高的文章 将以时间轴的方式排列出  另需查找历史上的今天API接口 （这点必须有）
      活动|  无论线上线下的活动 （只有小组才可以发布活动 且是否为公开活动，若未公开只有小组内部成员可访问，公开则相反）
      电台| 调用 虾米API
      除管理员后台外，还需为小组设置一定的权限 对组，组员，活动 进行管理操作
     

=================
Project：喵我  mewl.me
               miaul.me
            


开发周期：5月零20天（520 哇！）
采用框架：.NET4.0，MVC4，DDD, EF,DDD 

=================


数据库名：miaowsys 
项目解决方案名：Miaow

####命名规范：
项目解决方案，引用命名空间示例如下：  
```C#
using Miaow.Application.account.Dto
```
```C#
       
      [  Miaow.   前缀 
      注意命名规范 
      表名为例   m_user_info   
      所有表名   必须使用  前缀 m_+ 表名 +_info   （若为系统或管理表则前缀改为 sys_）
      其字段 user_id ,      (ID/编号 使用 MD5 加密程序)
             user_name,     
             user_email     
      ]
    

