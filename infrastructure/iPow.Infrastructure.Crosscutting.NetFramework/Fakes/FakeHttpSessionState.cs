using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.SessionState;

namespace iPow.Infrastructure.Crosscutting.NetFramework.Fakes
{
    /// <summary>
    /// 
    /// </summary>
    public class FakeHttpSessionState : HttpSessionStateBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly SessionStateItemCollection _sessionItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeHttpSessionState"/> class.
        /// </summary>
        /// <param name="sessionItems">The session items.</param>
        public FakeHttpSessionState(SessionStateItemCollection sessionItems)
        {
            _sessionItems = sessionItems;
        }

        /// <summary>
        /// 在派生类中重写时，获取会话状态集合中的项数。
        /// </summary>
        /// <value></value>
        /// <returns>集合中的项数。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override int Count
        {
            get { return _sessionItems.Count; }
        }

        /// <summary>
        /// 在派生类中重写时，获取存储在会话状态集合中的所有值的密钥集合。
        /// </summary>
        /// <value></value>
        /// <returns>会话密钥。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override NameObjectCollectionBase.KeysCollection Keys
        {
            get { return _sessionItems.Keys; }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified name.
        /// </summary>
        /// <value></value>
        public override object this[string name]
        {
            get { return _sessionItems[name]; }
            set { _sessionItems[name] = value; }
        }

        /// <summary>
        /// Existses the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            return _sessionItems[key] != null;
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> at the specified index.
        /// </summary>
        /// <value></value>
        public override object this[int index]
        {
            get { return _sessionItems[index]; }
            set { _sessionItems[index] = value; }
        }

        /// <summary>
        /// 在派生类中重写时，将一个项添加到会话状态集合。
        /// </summary>
        /// <param name="name">要添加到会话状态集合的项的名称。</param>
        /// <param name="value">要添加到会话状态集合的项的值。</param>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override void Add(string name, object value)
        {
            _sessionItems[name] = value;
        }

        /// <summary>
        /// 在派生类中重写时，返回一个枚举数，该枚举数可用于读取当前会话中的所有会话状态变量名称。
        /// </summary>
        /// <returns>可以循环访问会话状态集合中的变量名称的枚举数。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override IEnumerator GetEnumerator()
        {
            return _sessionItems.GetEnumerator();
        }

        /// <summary>
        /// 在派生类中重写时，从会话状态集合中删除一个项。
        /// </summary>
        /// <param name="name">要从会话状态集合中删除的项的名称。</param>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override void Remove(string name)
        {
            _sessionItems.Remove(name);
        }
    }
}