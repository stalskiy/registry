using System;
using System.Collections.Generic;
using System.Text;

namespace Registry.Core.Infrastructure
{
    /// <summary>
    /// A file provider abstraction
    /// </summary>
    public interface IEngineFileProvider
    {
        /// <summary>
        /// Combines an array of strings into a path
        /// </summary>
        /// <param name="paths">An array of parts of the path</param>
        /// <returns>The combined paths</returns>
        string Combine(params string[] paths);

        /// <summary>
        /// Maps a virtual path to a physical disk path.
        /// </summary>
        /// <param name="path">The path to map. E.g. "~/bin"</param>
        /// <returns>The physical path. E.g. "c:\inetpub\wwwroot\bin"</returns>
        string MapPath(string path);

    }
}
