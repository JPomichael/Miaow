using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Autofac;
using iPow.Infrastructure.Crosscutting.NetFramework.Infrastructure;

namespace iPow.Infrastructure.Crosscutting.NetFramework.Plugins
{
    public class PluginDescriptor : IComparable<PluginDescriptor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PluginDescriptor"/> class.
        /// </summary>
        public PluginDescriptor()
        {
            this.SupportedVersions = new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginDescriptor"/> class.
        /// </summary>
        /// <param name="referencedAssembly">The referenced assembly.</param>
        /// <param name="originalAssemblyFile">The original assembly file.</param>
        /// <param name="pluginType">Type of the plugin.</param>
        public PluginDescriptor(Assembly referencedAssembly, FileInfo originalAssemblyFile,
            Type pluginType)
            : this()
        {
            this.ReferencedAssembly = referencedAssembly;
            this.OriginalAssemblyFile = originalAssemblyFile;
            this.PluginType = pluginType;
        }

        /// <summary>
        /// Plugin type
        /// </summary>
        /// <value>The name of the plugin file.</value>
        public virtual string PluginFileName { get; set; }

        /// <summary>
        /// Plugin type
        /// </summary>
        /// <value>The type of the plugin.</value>
        public virtual Type PluginType { get; set; }

        /// <summary>
        /// The assembly that has been shadow copied that is active in the application
        /// </summary>
        /// <value>The referenced assembly.</value>
        public virtual Assembly ReferencedAssembly { get; internal set; }

        /// <summary>
        /// The original assembly file that a shadow copy was made from it
        /// </summary>
        /// <value>The original assembly file.</value>
        public virtual FileInfo OriginalAssemblyFile { get; internal set; }

        /// <summary>
        /// Gets or sets the plugin group
        /// </summary>
        public virtual string Group { get; set; }

        /// <summary>
        /// Gets or sets the friendly name
        /// </summary>
        /// <value>The name of the friendly.</value>
        public virtual string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the system name
        /// </summary>
        /// <value>The name of the system.</value>
        public virtual string SystemName { get; set; }

        /// <summary>
        /// Gets or sets the version
        /// </summary>
        /// <value>The version.</value>
        public virtual string Version { get; set; }

        /// <summary>
        /// Gets or sets the supported versions of nopCommerce
        /// </summary>
        /// <value>The supported versions.</value>
        public virtual IList<string> SupportedVersions { get; set; }

        /// <summary>
        /// Gets or sets the author
        /// </summary>
        /// <value>The author.</value>
        public virtual string Author { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        /// <value>The display order.</value>
        public virtual int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether plugin is installed
        /// </summary>
        /// <value><c>true</c> if installed; otherwise, <c>false</c>.</value>
        public virtual bool Installed { get; set; }

        /// <summary>
        /// Instances this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual T Instance<T>() where T : class, IPlugin
        {
            object instance;
            //ioc里面实例化，如果没有实例化的话
            if (!EngineContext.Current.ContainerManager.Scope().TryResolve(PluginType, out instance))
            {
                //not resolved
                try
                {
                    //直接创建
                    //如果失败
                    instance = Activator.CreateInstance(PluginType) as T;
                }
                catch (MissingMethodException)
                {
                    //
                    instance = EngineContext.Current.ContainerManager.ResolveUnregistered(PluginType) as T;
                }
            }
            var typedInstance = instance as T;
            if (typedInstance != null)
                typedInstance.PluginDescriptor = this;
            return typedInstance;
        }

        /// <summary>
        /// Instances this instance.
        /// </summary>
        /// <returns></returns>
        public IPlugin Instance()
        {
            return Instance<IPlugin>();
        }

        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public int CompareTo(PluginDescriptor other)
        {
            if (DisplayOrder != other.DisplayOrder)
                return DisplayOrder.CompareTo(other.DisplayOrder);
            else
                return FriendlyName.CompareTo(other.FriendlyName);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return FriendlyName;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var other = obj as PluginDescriptor;
            return other != null && 
                SystemName != null &&
                SystemName.Equals(other.SystemName);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return SystemName.GetHashCode();
        }
    }
}
