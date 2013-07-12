using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Infrastructure.Crosscutting.Function
{
    public enum HttpMethod
    {
        GET, POST, PUT, DELETE
    }

    public enum ProviderType
    {
        Default, Xml
    }

    public enum LoggerType
    {
        QuerySuccess = 1, //查询成功
        QueryFail = 2,//查询失败,
        LoginSuccess = 3,//登陆成功
        LoginFail = 4,//登陆失败
        AddSuccess = 5,//添加成功
        AddFail = 6,//添加失败
        ModifySuccess = 7,//修改成功
        ModifyFail = 8,//修改失败
        DeleteSuccess = 9,//删除成功
        DeleteFail = 10//删除失败
    }
}