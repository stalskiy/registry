using Microsoft.AspNetCore.Mvc.ModelBinding;
using Registry.Web.Extensions.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registry.Web.Extensions
{
    /// <summary>
    /// Common extantions
    /// </summary>
    public static class CommonExtentions
    {
        /// <summary>
        /// Get constant
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Constant value</returns>
        public static string Localize(this string key)
        {
            if (key == null)
                return null;

            if (LocalizationConstants.Ru.ContainsKey(key))
                return LocalizationConstants.Ru[key];
            else
                return string.Empty;
        }

        /// <summary>
        /// Get full error message
        /// </summary>
        /// <param name="modelState">Model state</param>
        /// <returns>Error message</returns>
        public static string GetFullErrorMessage(this ModelStateDictionary modelState)
        {
            var messages = new List<string>();

            foreach (var entry in modelState)
            {
                foreach (var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}
