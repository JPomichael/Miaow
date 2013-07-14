using System.Linq;
using System.Security.Principal;

namespace Miaow.Infrastructure.Crosscutting.NetFramework.Fakes
{
    /// <summary>
    /// 
    /// </summary>
    public class FakePrincipal : IPrincipal
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IIdentity _identity;

        /// <summary>
        /// 
        /// </summary>
        private readonly string[] _roles;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakePrincipal"/> class.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <param name="roles">The roles.</param>
        public FakePrincipal(IIdentity identity, string[] roles)
        {
            _identity = identity;
            _roles = roles;
        }

        /// <summary>
        /// 获取当前用户的标识。
        /// </summary>
        /// <value></value>
        /// <returns>与当前用户关联的 <see cref="T:System.Security.Principal.IIdentity"/> 对象。</returns>
        public IIdentity Identity
        {
            get { return _identity; }
        }

        /// <summary>
        /// 确定当前用户是否属于指定的角色。
        /// </summary>
        /// <param name="role">要检查其成员资格的角色的名称。</param>
        /// <returns>如果当前用户是指定角色的成员，则为 true；否则为 false。</returns>
        public bool IsInRole(string role)
        {
            return _roles != null && _roles.Contains(role);
        }
    }
}