using System;
using Autofac;

namespace iPow.Infrastructure.Crosscutting.NetFramework.Engines
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>The container.</value>
        IContainer Container { get; set; }

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>() where T : class;

        /// <summary>
        /// Resolves the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        object Resolve(Type type);

        /// <summary>
        /// Resolves all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T[] ResolveAll<T>(string key = "");
    }
}
