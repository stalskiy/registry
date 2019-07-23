using GeoAPI.Geometries;
using Registry.Core.Domain.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registry.Core.Domain.Areas
{
    /// <summary>
    /// Represents an area
    /// </summary>
    public class Area : BaseEntity
    {
        /// <summary>
        /// Gets or sets the area name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        ///  Gets or sets the inventory number
        /// </summary>
        public string InventoryNum { get; set; }

        /// <summary>
        /// Gets or sets the cadastral number
        /// </summary>
        public string CadastralNum { get; set; }

        /// <summary>
        ///  Gets or sets the area type identifier
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// /// <summary>
        /// Gets or sets the ownership type identifier
        /// </summary>
        /// </summary>
        public int OwnershipTypeId { get; set; }

        /// <summary>
        /// Gets or sets the document identifier
        /// </summary>
        public int DocumentId { get; set; }

        /// <summary>
        /// Gets or sets the area polygon
        /// </summary>
        public IPolygon Geometry { get; set; }

        /// <summary>
        /// Gets or sets the area type
        /// </summary>
        public virtual AreaType Type { get; set; }

        /// <summary>
        /// Gets or sets the ownership type
        /// </summary>
        public virtual AreaOwnershipType OwnershipType { get; set; }

        /// <summary>
        /// Gets or sets the area document
        /// </summary>
        public virtual AreaDocument Document { get; set; }
    }
}
