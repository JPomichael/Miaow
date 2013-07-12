using System;
using System.Diagnostics;
using System.Configuration;
using System.Runtime.CompilerServices;
using iPow.Infrastructure.Crosscutting.Function;

namespace iPow.Infrastructure.Crosscutting.NetFramework.Engines
{
    /// <summary>
    /// 
    /// </summary>
    public class EngineManager
    {
        #region Initialization Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize()
        {
            if (SingletonHelper<iPowEngine>.Instance == null)
            {
                SingletonHelper<iPowEngine>.Instance = new iPowEngine();
            }
            return SingletonHelper<iPowEngine>.Instance;
        }

        /// <summary>
        /// Sets the static engine instance to the supplied engine. Use this method to supply your own engine implementation.
        /// </summary>
        /// <param name="engine">The engine to use.</param>
        /// <remarks>Only use this method if you know what you're doing.</remarks>
        public static void Replace(iPowEngine engine)
        {
            SingletonHelper<iPowEngine>.Instance = engine;
        }

        #endregion

        /// <summary>
        /// Gets the singleton Nop engine used to access Nop services.
        /// </summary>
        /// <value>The current.</value>
        public static IEngine Current
        {
            get
            {
                if (SingletonHelper<iPowEngine>.Instance == null)
                {
                    SingletonHelper<iPowEngine>.Instance = new iPowEngine();
                }
                return SingletonHelper<iPowEngine>.Instance;
            }
        }
    }
}
