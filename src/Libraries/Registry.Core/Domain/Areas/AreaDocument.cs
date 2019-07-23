using System;
using System.Collections.Generic;
using System.Text;

namespace Registry.Core.Domain.Areas
{
    /// <summary>
    /// Represents an area document
    /// </summary>
    public class AreaDocument : BaseEntity
    {
        /// <summary>
        ///  Gets or sets the document file
        /// </summary>
        public byte[] File { get; set; }
    }
}
