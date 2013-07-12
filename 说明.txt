1、方案文件夹说明
基本上的方案文件夹都对应了一个真实有文件夹，除方案文件夹：”项目必看“没有
如有添加方案文件夹的话，请同时添加真实文件夹到相应目录
2、dll说明
2.1：dll引用说明
用nuget引用就行了，在IPOW文件夹下面有一个packages文件夹，这个文件夹是nuget产生的，部分dll，nuget没有，所以得手到放到这个文件夹下面
比如说：邮件发送DLL：Dimac.JMail
图片截图DLL：Interop.ASPJPEGLib
2.2：签入说明
如果引用了新的dll则得手动将文件夹packages签入，而不是在VS里面签入，在VS里面是不能签入packages包的。 

3、各层说明
3.1、domain
1、Dto转换model：iPow.Domain.Dto
2、定义接口：iPow.Domain.Infrastructure
3、基础接口的扩展：iPow.Domain.Repository
而不是真正的DDD分层模式开发，因为用的是database first开发，而不是code first开发
3.2、infrastructure
iPow.Infrastructure.Crosscutting
定义了日志记录接口，验证码类
iPow.Infrastructure.Crosscutting.Comm.Dto
Comm.Service要用到的模型
iPow.Infrastructure.Crosscutting.Comm.Service
度假，景区，酒店要用到的公用方法，公用类，（图片获取，优惠信息，用户类）
iPow.Infrastructure.Crosscutting.Function
公用类库，时间，字符串，加密，Cookie，Session，File，XML，
iPow.Infrastructure.Crosscutting.NetFramework
表现层要用到的基Controller，属性，Ioc，一些接口的定义
iPow.Infrastructure.Crosscutting.OAuth.QQ
iPow.Infrastructure.Crosscutting.OAuth.Sina
iPow.Infrastructure.Data
Uow方式的实现，也就是项目iPow.Domain.Infrastructure的实现
iPow.Infrastructure.Data.DataSys
模型及数据访问最低层
iPow.Infrastructure.Data.Repository
数据访问类
3.3、application
3.4、distributed services
3.5、presentation
表现层
4、mvcpager控件
主项目路径：infrastructure/crosscutting/MvcPager
项目已经有很多更新的了,比如说分页控件部分项目没有更新：iPow.jd项目没有更新，若是要更新的话，请更新这些地方
用到分页的地方大概有
1、搜索
2、酒店评论
分页用了新版的，适合MVC3，所以在分页的时候，得加上了个js，源码可以在codeplex上找到
5、项目iPow.Presentation.jd说明
这个项目是酒店，已经没有上线了，所以，在说明文档产生之前的改动都没有对该项目进行改动，
涉及到的项目都在presentation/jd路径下
取而代之的是iPow.Union酒店项目
6、项目存在的问题
7、开发注意事项
7.1、在code first 方式下开发的话
领域模型层开发注意事项,记得继承domain/infrastructure/iPow.Domain.Infrastructure/Repositories/EntityBase.cs这个领域模型基类，
7.2、表现层开发注意事项，表现层里面的每一个Controller都要继承infrastructure/crosscutting/iPow.Web.Core/Controller/ControllerBase.cs这个控制器基类
7.3、开发过程中记得LOCK文件，修改每一个文件的时候，记得很更新文件哦
8、SSO注意事项
8.1、SSOPartial引用
8.2、_logonPartial改变
8.3、退出action



********************************************************************************************************************************
IPOW解决方案说明v1
create by
user:yjihrp
time:2012.1.11.10.04

modify by
user:yjihrp
time:2012.2.9.17.41
********************************************************************************************************************************



iPow.Application.dj

TourPlanService,ITourPlanService
引用了
iPow.Service.Union.Services.ICityService ucityService（没有依赖）
iPow.Service.Union.Services.IHotelLeftMidService hlmService（只依赖于上面的ICityService）
这两个只


1\iPow.Application.jq.Service
2\iPow.Application.dj.Dto
3\iPow.Application.dj.Service


iPow.Presentation.jq

SightDetailController	119-126
PicController	95

模型验证时记得在模型上添加验证属性


