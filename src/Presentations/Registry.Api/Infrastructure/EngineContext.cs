using Registry.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Registry.Api.Infrastructure
{
    /// <summary>
    /// Provides access to the singleton instance of the Nop engine.
    /// </summary>
    public class EngineContext
    {
        #region Methods

        /// <summary>
        /// Create a static instance of the Nop engine.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IRegistryEngine Create()
        {
            //create engine
            return Singleton<IRegistryEngine>.Instance ?? (Singleton<IRegistryEngine>.Instance = new RegistryEngine());
        }

        /// <summary>
        /// Sets the static engine instance to the supplied engine. Use this method to supply your own engine implementation.
        /// </summary>
        /// <param name="engine">The engine to use.</param>
        /// <remarks>Only use this method if you know what you're doing.</remarks>
        public static void Replace(IRegistryEngine engine)
        {
            Singleton<IRegistryEngine>.Instance = engine;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the singleton engine used to access services.
        /// </summary>
        public static IRegistryEngine Current
        {
            get
            {
                if (Singleton<IRegistryEngine>.Instance == null)
                {
                    Create();
                }

                return Singleton<IRegistryEngine>.Instance;
            }
        }

        #endregion
    }
}
