using Registry.Web.Extensions.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registry.Web.Models
{
    /// <summary>
    /// Base model
    /// </summary>
    public class ModelBase
    {
        /// <summary>
        /// Get constant
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Constant value</returns>
        public static string T(string key)
        {
            if (LocalizationConstants.Ru.ContainsKey(key))
                return LocalizationConstants.Ru[key];
            else
                return string.Empty;
        }
    }
}
