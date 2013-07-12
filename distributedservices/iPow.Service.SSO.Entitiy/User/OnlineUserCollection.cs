using System.Collections.ObjectModel;

namespace iPow.Service.SSO.Entity
{
    public class OnlineUserCollection : KeyedCollection<string, OnlineUser>
    {
        /// <summary>
        /// When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <param name="item">The element from which to extract the key.</param>
        /// <returns>The key for the specified element.</returns>
        protected override string GetKeyForItem(OnlineUser item)
        {
            return item.username;
        }
    }
}
