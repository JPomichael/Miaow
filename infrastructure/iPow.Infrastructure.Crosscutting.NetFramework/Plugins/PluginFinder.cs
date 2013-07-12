using System;
using System.Collections.Generic;
using System.Linq;
using iPow.Infrastructure.Crosscutting.NetFramework.Infrastructure;
using iPow.Infrastructure.Crosscutting.NetFramework.Infrastructure.DependencyManagement;

namespace iPow.Infrastructure.Crosscutting.NetFramework.Plugins
{
    /// <summary>
    /// Investigates the execution environment to find plugins.
    /// </summary>
    [Dependency(typeof(IPluginFinder))]
    public class PluginFinder : IPluginFinder
    {
        /// <summary>
        /// 
        /// </summary>
        private IList<PluginDescriptor> _plugins;

        /// <summary>
        /// 
        /// </summary>
        private bool _arePluginsLoaded = false;

        /// <summary>
        /// 
        /// </summary>
        private readonly ITypeFinder _typeFinder;

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginFinder"/> class.
        /// </summary>
        /// <param name="typeFinder">The type finder.</param>
        public PluginFinder(ITypeFinder typeFinder)
        {
            this._typeFinder = typeFinder;
        }

        /// <summary>
        /// Gets plugins found in the environment sorted.
        /// </summary>
        /// <typeparam name="T">The type of plugin to get.</typeparam>
        /// <param name="installedOnly"></param>
        /// <returns>An enumeration of plugins.</returns>
        public virtual IEnumerable<T> GetPlugins<T>(bool installedOnly = true) where T : class, IPlugin
        {
            EnsurePluginsAreLoaded();

            foreach (var plugin in _plugins)
                if (typeof(T).IsAssignableFrom(plugin.PluginType))
                    if (!installedOnly || plugin.Installed)
                        yield return plugin.Instance<T>();
        }

        /// <summary>
        /// Gets the plugin descriptors.
        /// </summary>
        /// <param name="installedOnly">if set to <c>true</c> [installed only].</param>
        /// <returns></returns>
        public virtual IEnumerable<PluginDescriptor> GetPluginDescriptors(bool installedOnly = true)
        {
            EnsurePluginsAreLoaded();

            foreach (var plugin in _plugins)
                if (!installedOnly || plugin.Installed)
                    yield return plugin;
        }

        /// <summary>
        /// Gets the plugin descriptors.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="installedOnly">if set to <c>true</c> [installed only].</param>
        /// <returns></returns>
        public virtual IEnumerable<PluginDescriptor> GetPluginDescriptors<T>(bool installedOnly = true) where T : class, IPlugin
        {
            EnsurePluginsAreLoaded();

            foreach (var plugin in _plugins)
                if (typeof(T).IsAssignableFrom(plugin.PluginType))
                    if (!installedOnly || plugin.Installed)
                        yield return plugin;
        }

        /// <summary>
        /// Gets the name of the plugin descriptor by system.
        /// </summary>
        /// <param name="systemName">Name of the system.</param>
        /// <param name="installedOnly">if set to <c>true</c> [installed only].</param>
        /// <returns></returns>
        public virtual PluginDescriptor GetPluginDescriptorBySystemName(string systemName, bool installedOnly = true)
        {
            return GetPluginDescriptors(installedOnly)
                .SingleOrDefault(p => p.SystemName.Equals(systemName, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Gets the name of the plugin descriptor by system.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="systemName">Name of the system.</param>
        /// <param name="installedOnly">if set to <c>true</c> [installed only].</param>
        /// <returns></returns>
        public virtual PluginDescriptor GetPluginDescriptorBySystemName<T>(string systemName, bool installedOnly = true) where T : class, IPlugin
        {
            return GetPluginDescriptors<T>(installedOnly)
                .SingleOrDefault(p => p.SystemName.Equals(systemName, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Finds and sorts plugin defined in known assemblies.
        /// </summary>
        /// <returns>A sorted list of plugins.</returns>
        protected virtual IList<PluginDescriptor> FindAllPlugins()
        {
            var foundPlugins = PluginManager.ReferencedPlugins.ToList();
            //sort
            foundPlugins.Sort();
            return foundPlugins.ToList();
        }

        /// <summary>
        /// Ensures the plugins are loaded.
        /// </summary>
        protected virtual void EnsurePluginsAreLoaded()
        {
            if (!_arePluginsLoaded)
            {
                _plugins = FindAllPlugins();
                _arePluginsLoaded = true;
            }
        }
    }
}
