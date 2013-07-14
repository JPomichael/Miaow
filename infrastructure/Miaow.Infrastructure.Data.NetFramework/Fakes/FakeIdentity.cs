using System;
using System.Security.Principal;

namespace Miaow.Infrastructure.Crosscutting.NetFramework.Fakes
{
    /// <summary>
    /// 
    /// </summary>
    public class FakeIdentity : IIdentity
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeIdentity"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        public FakeIdentity(string userName)
        {
            _name = userName;
        }

        /// <summary>
        /// 获取所使用的身份验证的类型。
        /// </summary>
        /// <value></value>
        /// <returns>用于标识用户的身份验证的类型。</returns>
        public string AuthenticationType
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// 获取一个值，该值指示是否验证了用户。
        /// </summary>
        /// <value></value>
        /// <returns>如果用户已经过验证，则为 true；否则为 false。</returns>
        public bool IsAuthenticated
        {
            get { return !String.IsNullOrEmpty(_name); }
        }

        /// <summary>
        /// 获取当前用户的名称。
        /// </summary>
        /// <value></value>
        /// <returns>用户名，代码当前即以该用户的名义运行。</returns>
        public string Name
        {
            get { return _name; }
        }

    }
}