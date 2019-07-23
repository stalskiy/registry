using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Registry.Core.Infrastructure
{
    /// <summary>
    /// File provider
    /// </summary>
    public class EngineFileProvider : IEngineFileProvider
    {
        #region Methods

        /// <summary>
        /// Combines an array of strings into a path
        /// </summary>
        /// <param name="paths">An array of parts of the path</param>
        /// <returns>The combined paths</returns>
        public virtual string Combine(params string[] paths)
        {
            var path = System.IO.Path.Combine(paths.SelectMany(p => p.Split('\\', '/')).ToArray());

            if (path.Contains('/'))
                path = "/" + path;

            return path;
        }

        /// <summary>
        /// Maps a virtual path to a physical disk path.
        /// </summary>
        /// <param name="path">The path to map. E.g. "~/bin"</param>
        /// <returns>The physical path. E.g. "c:\inetpub\wwwroot\bin"</returns>
        public virtual string MapPath(string path)
        {
            path = path.Replace("~/", string.Empty).TrimStart('/');
            return Combine(BaseDirectory ?? string.Empty, path);
        }

        #endregion

        protected string BaseDirectory { get; }
    }
}
