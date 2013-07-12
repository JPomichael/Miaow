using System.Collections.ObjectModel;

namespace iPow.Service.SSO.Entity
{
    public class SecurityTokenCollection : KeyedCollection<string, SecurityToken>
    {
        /// <summary>
        /// When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <param name="item">The element from which to extract the key.</param>
        /// <returns>The key for the specified element.</returns>
        protected override string GetKeyForItem(SecurityToken item)
        {
            return item.TokenId;
        }
    }
}
