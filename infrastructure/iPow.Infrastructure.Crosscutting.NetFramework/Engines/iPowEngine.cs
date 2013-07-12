using System;
using System.Linq;

using Autofac;
using System.Collections.Generic;

namespace iPow.Infrastructure.Crosscutting.NetFramework.Engines
{
    /// <summary>
    /// 
    /// </summary>
    public class iPowEngine : IEngine
    {
        /// <summary>
        /// 
        /// </summary>
        Autofac.IContainer container;

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>() where T : class
        {
            return GetLifeTimeScope().Resolve<T>();
        }

        /// <summary>
        /// Resolves the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public object Resolve(Type type)
        {
            return GetLifeTimeScope().Resolve(type);
        }

        /// <summary>
        /// Resolves all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T[] ResolveAll<T>(string key = "")
        {
            if (string.IsNullOrEmpty(key))
            {
                return GetLifeTimeScope().Resolve<IEnumerable<T>>().ToArray();
            }
            return GetLifeTimeScope().ResolveKeyed<IEnumerable<T>>(key).ToArray();
        }

        /// <summary>
        /// Gets or sets the life time scope.
        /// </summary>
        /// <returns></returns>
        /// <value>The life time scope.</value>
        protected Autofac.ILifetimeScope GetLifeTimeScope()
        {
            try
            {
                return iPowRltHttpModule.GetLifetimeScope(container, null);
            }
            catch (Exception ex)
            {
                return container;
            }
        }

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>The container.</value>
        public Autofac.IContainer Container
        {
            get
            {
                return container;
            }
            set
            {
                container = value;
            }
        }
    }
}
