using System;
using System.Collections.Generic;
using System.Text;

namespace Registry.Core.Domain.References
{
    /// <summary>
    /// Represents an area type
    /// </summary>
    public class AreaType : BaseEntity
    {
        /// <summary>
        /// Gets or sets the area type name
        /// </summary>
        public string Name { get; set; }
    }
}
