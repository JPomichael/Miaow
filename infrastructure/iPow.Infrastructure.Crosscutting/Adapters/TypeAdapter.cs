using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

using iPow.Infrastructure.Crosscutting.Adapters;

namespace iPow.Infrastructure.Crosscutting.Adapters
{

    /// <summary>
    /// ITypeAdatper implementation.
    /// <remarks>
    /// Really, this implementation only load RegisterTypesMapConfiguration
    /// and create a global dictionary of mappers.
    /// </remarks>
    /// </summary>
    public sealed class TypeAdapter
        : ITypeAdapter
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        Dictionary<string, ITypeMapConfigurationBase> _maps;

        /// <summary>
        /// Get the collection of ITypeMapConfigurationBase elements
        /// </summary>
        /// <value>The maps.</value>
        public Dictionary<string, ITypeMapConfigurationBase> Maps
        {
            get
            {
                return _maps;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Create a instance of TypeAdapter
        /// </summary>
        /// <param name="mapModules">The map modules.</param>
        public TypeAdapter(RegisterTypesMap[] mapModules)
        {
            InitializeAdapter(mapModules);
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Initializes the adapter.
        /// </summary>
        /// <param name="mapsModules">The maps modules.</param>
        void InitializeAdapter(RegisterTypesMap[] mapsModules)
        {
            //create map adapters dictionary
            _maps = new Dictionary<string, ITypeMapConfigurationBase>();

            if (mapsModules != null)
            {
                //foreach adapter's module in solution load mapping
                foreach (var module in mapsModules)
                {
                    foreach (var map in module.Maps)
                        _maps.Add(map.Key, map.Value);
                }
            }
        }

        #endregion

        #region ITypeAdapter Implementation

        /// <summary>
        /// 	<see cref="iPow.Infrastructure.Crosscutting.Adapters.ITypeAdapter"/>
        /// </summary>
        /// <typeparam name="TSource"><see cref="iPow.Infrastructure.Crosscutting.Adapters.ITypeAdapter"/></typeparam>
        /// <typeparam name="TTarget"><see cref="iPow.Infrastructure.Crosscutting.Adapters.ITypeAdapter"/></typeparam>
        /// <param name="source"><see cref="iPow.Infrastructure.Crosscutting.Adapters.ITypeAdapter"/></param>
        /// <returns>
        /// 	<see cref="iPow.Infrastructure.Crosscutting.Adapters.ITypeAdapter"/>
        /// </returns>
        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            if (source == (TSource)null)
            {
                throw new ArgumentNullException("source");
            }
            var descriptor = TypeMapConfigurationBase<TSource, TTarget>.GetDescriptor();
            if (_maps.ContainsKey(descriptor))
            {
                var spec = _maps[descriptor] as TypeMapConfigurationBase<TSource, TTarget>;
                return spec.Resolve(source);
            }
            else
            {
                throw new InvalidOperationException(string.Format("Not mapped found for type {0} to type {1}",
                                                                   typeof(TSource).FullName,
                                                                   typeof(TTarget).FullName));
            }
        }

        /// <summary>
        /// 	<see cref="iPow.Infrastructure.Crosscutting.Adapters.ITypeAdapter"/>
        /// </summary>
        /// <typeparam name="TSource"><see cref="iPow.Infrastructure.Crosscutting.Adapters.ITypeAdapter"/></typeparam>
        /// <typeparam name="TTarget"><see cref="iPow.Infrastructure.Crosscutting.Adapters.ITypeAdapter"/></typeparam>
        /// <param name="source"><see cref="iPow.Infrastructure.Crosscutting.Adapters.ITypeAdapter"/></param>
        /// <param name="moreSources"><see cref="iPow.Infrastructure.Crosscutting.Adapters.ITypeAdapter"/></param>
        /// <returns>
        /// 	<see cref="iPow.Infrastructure.Crosscutting.Adapters.ITypeAdapter"/>
        /// </returns>
        public TTarget Adapt<TSource, TTarget>(TSource source, params object[] moreSources)
            where TSource : class
            where TTarget : class, new()
        {

            if (source == (TSource)null)
            {
                throw new ArgumentNullException("source");
            }
            string descriptor = TypeMapConfigurationBase<TSource, TTarget>.GetDescriptor();
            if (_maps.ContainsKey(descriptor))
            {
                var spec = _maps[descriptor] as TypeMapConfigurationBase<TSource, TTarget>;
                return spec.Resolve(source, moreSources);
            }
            else
            {
                throw new InvalidOperationException(string.Format("Not mapped found for type {0} to type {1}",
                                                                   typeof(TSource).FullName,
                                                                   typeof(TTarget).FullName));
            }
        }

        #endregion
    }
}
