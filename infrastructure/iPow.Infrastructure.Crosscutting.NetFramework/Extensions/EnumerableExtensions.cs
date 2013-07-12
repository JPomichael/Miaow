using System.Collections.Generic;
using System.Linq;

namespace iPow.Infrastructure.Crosscutting.NetFramework.Extensions
{

    /// <summary>
    /// 
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Determines whether the specified source is empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>
        /// 	<c>true</c> if the specified source is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }

        /// <summary>
        /// Determines whether [is not empty] [the specified source].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>
        /// 	<c>true</c> if [is not empty] [the specified source]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> source)
        {
            return source.Any();
        }
    }
}

