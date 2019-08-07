using Microsoft.AspNetCore.Mvc.Razor;
using Registry.Web.Extensions.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registry.Web.Extensions
{
    /// <summary>
    /// Razor page extensions
    /// </summary>
    public static class RazorPageExtensions
    {
        /// <summary>
        /// Get constant
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Constant value</returns>
        public static string T(this RazorPage page, string key)
        {
            if (LocalizationConstants.Ru.ContainsKey(key))
                return LocalizationConstants.Ru[key];
            else
                return string.Empty;
        }
    }
}
