using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Infrastructure.Crosscutting.OAuth.QQ.Authenticators;

namespace iPow.Infrastructure.Crosscutting.OAuth.QQ.Api
{
    public partial class RestApi
    {
        /// <summary>
        /// 获取财付通用户的收货地址。一个用户可能设置了多条收货地址信息。
        /// 查询的用户必须为财付通用户，否则查询将返回失败。
        /// </summary>
        /// <param name="offset">表示查询收货地址的偏移量，一般情况下offset可以不传值或传入0，表示从第一条开始读取。
        /// offset参数是为一种特殊情况准备的，即该收货人有很多条收获地址，需要分页展示，则offset可设置为该页显示的条数。例如如果offset为10，则会跳过第10条收货地址，从第11条收货地址开始读取。 
        /// </param>
        /// <param name="limit">表示查询收货地址的返回限制数（即最多期望返回几个收货地址）。 limit不传默认按照5来处理。
        /// </param>
        /// <param name="ver">用于接口版本控制。固定填1。</param>
        /// <returns></returns>
        public string GetTenpayAddr(string offset, string limit="5", string ver="1")
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateGetTenpayAddrRequest(offset, limit, ver);

            var response = Execute(request);
            //var payload = Deserialize<AddWeiboResult>(response.Content);
            return response.Content;
        }
    }
}
