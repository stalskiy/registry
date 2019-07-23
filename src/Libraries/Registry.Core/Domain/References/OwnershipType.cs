using System;
using System.Collections.Generic;
using System.Text;

namespace Registry.Core.Domain.References
{
    /// <summary>
    /// Represents a ownership type
    /// </summary>
    public class OwnershipType : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ownership type name
        /// </summary>
        public string Name { get; set; }
    }
}
