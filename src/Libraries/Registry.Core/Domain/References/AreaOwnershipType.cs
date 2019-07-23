using System;
using System.Collections.Generic;
using System.Text;

namespace Registry.Core.Domain.References
{
    /// <summary>
    /// Represents a area ownership type
    /// </summary>
    public class AreaOwnershipType : BaseEntity
    {
        /// <summary>
        /// Gets or sets the area ownership type name
        /// </summary>
        public string Name { get; set; }
    }
}
