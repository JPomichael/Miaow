using System.Text;
using System.Web;

namespace iPow.Infrastructure.Crosscutting.NetFramework.Fakes
{
    /// <summary>
    /// 
    /// </summary>
    public class FakeHttpResponse : HttpResponseBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly StringBuilder _outputString = new StringBuilder();

        /// <summary>
        /// Gets the response output.
        /// </summary>
        /// <value>The response output.</value>
        public string ResponseOutput
        {
            get { return _outputString.ToString(); }
        }

        /// <summary>
        /// 在派生类中重写时，获取或设置返回到客户端的输出的 HTTP 状态代码。
        /// </summary>
        /// <value></value>
        /// <returns>返回到客户端的 HTTP 输出的状态代码。有关有效状态代码的信息，请参见 MSDN 网站上的 HTTP Status Codes（HTTP 状态代码）。</returns>
        /// <exception cref="T:System.NotImplementedException">总是。</exception>
        public override int StatusCode { get; set; }

        /// <summary>
        /// 在派生类中重写时，获取或设置 HTTP Location 标头的值。
        /// </summary>
        /// <value></value>
        /// <returns>HTTP Location 标头的绝对 URL。</returns>
        /// <exception cref="T:System.NotImplementedException">总是。</exception>
        public override string RedirectLocation { get; set; }

        /// <summary>
        /// 在派生类中重写时，将指定字符串写入 HTTP 响应输出流。
        /// </summary>
        /// <param name="s">要写入 HTTP 输出流的字符串。</param>
        /// <exception cref="T:System.NotImplementedException">总是。</exception>
        public override void Write(string s)
        {
            _outputString.Append(s);
        }

        /// <summary>
        /// 在派生类中重写时，如果会话使用的是 <see cref="P:System.Web.Configuration.SessionStateSection.Cookieless"/> 会话状态，则将会话 ID 添加到虚拟路径，并返回组合后的路径。
        /// </summary>
        /// <param name="virtualPath">资源的虚拟路径。</param>
        /// <returns>插入了会话 ID 的虚拟路径。</returns>
        /// <exception cref="T:System.NotImplementedException">总是。</exception>
        public override string ApplyAppPathModifier(string virtualPath)
        {
            return virtualPath;
        }
    }
}