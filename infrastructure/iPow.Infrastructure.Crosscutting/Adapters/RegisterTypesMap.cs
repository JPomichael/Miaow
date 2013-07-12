using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Adapters
{
    /// <summary>
    /// Base class from ModuleTypesAdapter. This class
    /// is intended to subclasing for each module in
    /// solution to configure specific maps
    /// </summary>
    public abstract class RegisterTypesMap
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        Dictionary<string, ITypeMapConfigurationBase> maps;

        /// <summary>
        /// Get the dictionary of type maps
        /// </summary>
        /// <value>The maps.</value>
        public Dictionary<string, ITypeMapConfigurationBase> Maps
        {
            get
            {
                return maps;
            }
        }


        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of ModulesTypeAdapter
        /// </summary>
        public RegisterTypesMap()
        {
            //create a new instance of type maps dictionary
            maps = new Dictionary<string, ITypeMapConfigurationBase>();
        }

        #endregion

        #region Public Abstract Methods

        /// <summary>
        /// Register map into this register types map
        /// </summary>
        /// <typeparam name="TSource">The source type</typeparam>
        /// <typeparam name="TTarget">The type of the target.</typeparam>
        /// <param name="map">The map to register</param>
        public void RegisterMap<TSource, TTarget>(TypeMapConfigurationBase<TSource, TTarget> map)
            where TSource : class
            where TTarget : class,new()
        {
            if (map == (TypeMapConfigurationBase<TSource, TTarget>)null)
            {
                throw new ArgumentNullException("map");
            }
            maps.Add(map.Descriptor, map);
        }

        #endregion

    }
}
