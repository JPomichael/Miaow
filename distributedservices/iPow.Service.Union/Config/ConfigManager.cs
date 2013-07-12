using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Service.Union.Config
{
    public class ConfigManager
    {
        /// <summary>
        /// Gets the config provider.
        /// </summary>
        /// <returns></returns>
        public static IUnionConfig GetConfigProvider()
        {
            var config = new iPow.Service.Union.Config.DefaultUnionConfig();
            return config;
        }
    }
}