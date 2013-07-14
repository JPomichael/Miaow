using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Infrastructure.Crosscutting.OAuth.QQ.Context;
using iPow.Infrastructure.Crosscutting.OAuth.QQ.Config;
using iPow.Infrastructure.Crosscutting.OAuth.QQ.Models;
using RestSharp.Deserializers;
using iPow.Infrastructure.Crosscutting.OAuth.QQ.Exceptions;
using iPow.Infrastructure.Crosscutting.OAuth.QQ.Authenticators;
using RestSharp;
using System.Net;

namespace iPow.Infrastructure.Crosscutting.OAuth.QQ.Api
{
    /// <summary>
    /// QQ登录API
    /// </summary>
    public partial class RestApi
    {
        private QzoneContext context;
        /// <summary>
        /// QQ互联API的上下文数据
        /// </summary>
        public QzoneContext Context
        {
            get { return context; }
            set { context = value; }
        }

        private RestClient _restClient;

        private RequestHelper _requestHelper;

        /// <summary>
        /// 构造函数，初始化访问QQ互联API的上下文数据
        /// </summary>
        /// <param name="context"></param>
        public RestApi(QzoneContext context)
        {
            this.context = context;
            this._requestHelper = new RequestHelper();
            _restClient = new RestClient(Endpoints.ApiBaseUrl);
        }

        #region 私有辅助方法
        private void ExecuteAsync(RestRequest request, Action<RestResponse> success, Action<QzoneException> failure)
        {
#if WINDOWS_PHONE
            //check for network connection
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                //do nothing
                failure(new QzoneException
                {
                    StatusCode = System.Net.HttpStatusCode.BadGateway
                });
                return;
            }
#endif
            _restClient.ExecuteAsync(request, (response) =>
            {
                var error = response as RestResponse;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    failure(new QzoneException(error));
                }
                else
                {
                    success(error);
                }
            });
        }

#if !WINDOWS_PHONE
        private RestSharp.RestResponse Execute(RestRequest request)
        {
            var response = _restClient.Execute(request) as RestResponse;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new QzoneException(response);
            }
            return response;
        }
#endif

        private T Deserialize<T>(string content) where T : new()
        {
            var restResponse = new RestResponse { Content = content };
            var d = new JsonDeserializer();
            var payload = d.Deserialize<T>(restResponse);
            return payload;
        }

        #endregion
    }
}
