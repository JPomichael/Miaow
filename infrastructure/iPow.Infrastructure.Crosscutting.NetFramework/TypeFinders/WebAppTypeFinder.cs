using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System;
using System.IO;

namespace iPow.Infrastructure.Crosscutting.NetFramework.TypeFinders
{
    /// <summary>
    /// Provides information about types in the current web application.
    /// Optionally this class can look at all assemblies in the bin folder.
    /// </summary>
    public class WebAppTypeFinder : AppDomainTypeFinder
    {
        /// <summary>
        /// 
        /// </summary>
        private bool _ensureBinFolderAssembliesLoaded = true;

        /// <summary>
        /// 
        /// </summary>
        private bool _binFolderAssembliesLoaded = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebAppTypeFinder"/> class.
        /// </summary>
        public WebAppTypeFinder()
        {
            this._ensureBinFolderAssembliesLoaded = true;
        }

        /// <summary>
        /// Gets or sets wether assemblies in the bin folder of the web application should be specificly checked for beeing loaded on application load. This is need in situations where plugins need to be loaded in the AppDomain after the application been reloaded.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [ensure bin folder assemblies loaded]; otherwise, <c>false</c>.
        /// </value>
        public bool EnsureBinFolderAssembliesLoaded
        {
            get { return _ensureBinFolderAssembliesLoaded; }
            set { _ensureBinFolderAssembliesLoaded = value; }
        }

        /// <summary>
        /// Gets tne assemblies related to the current implementation.
        /// </summary>
        /// <returns>
        /// A list of assemblies that should be loaded by the Nop factory.
        /// </returns>
        public override IList<Assembly> GetAssemblies()
        {
            if (this.EnsureBinFolderAssembliesLoaded && !_binFolderAssembliesLoaded)
            {
                _binFolderAssembliesLoaded = true;
                LoadMatchingAssemblies(MapPath("~/bin"));
            }
            return base.GetAssemblies();
        }


        /// <summary>
        /// Maps a virtual path to a physical disk path.
        /// </summary>
        /// <param name="path">The path to map. E.g. "~/bin"</param>
        /// <returns>
        /// The physical path. E.g. "c:\inetpub\wwwroot\bin"
        /// </returns>
        public virtual string MapPath(string path)
        {
            if (HttpContext.Current != null)
            {
                return HostingEnvironment.MapPath(path);
            }
            else
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                int binIndex = baseDirectory.IndexOf("\\bin\\");
                if (binIndex >= 0)
                {
                    baseDirectory = baseDirectory.Substring(0, binIndex);
                }
                else if (baseDirectory.EndsWith("\\bin"))
                {
                    baseDirectory = baseDirectory.Substring(0, baseDirectory.Length - 4);
                }
                path = path.Replace("~/", "").TrimStart('/').Replace('/', '\\');
                return Path.Combine(baseDirectory, path);
            }
        }
    }
}
