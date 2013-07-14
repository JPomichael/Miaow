using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Miaow.Service.Union.Config
{
    public class ConfigManager
    {
        /// <summary>
        /// Gets the config provider.
        /// </summary>
        /// <returns></returns>
        public static IUnionConfig GetConfigProvider()
        {
            var config = new Miaow.Service.Union.Config.DefaultUnionConfig();
            return config;
        }
    }
}