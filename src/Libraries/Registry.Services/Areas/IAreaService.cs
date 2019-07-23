using Registry.Core.Domain.Areas;
using Registry.Core.Domain.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registry.Services.Areas
{
    /// <summary>
    /// Area service interface
    /// </summary>
    public partial interface IAreaService
    {
        /// <summary>
        /// Gets area by area identifier
        /// </summary>
        /// <param name="areaId">Area identifier</param>
        /// <returns>Area</returns>
        Area GetAreaById(int areaId);

        /// <summary>
        /// Gets all areas
        /// </summary>
        /// <returns>Areas</returns>
        IList<Area> GetAreasAll();

        /// <summary>
        /// Gets areas by areas identifiers
        /// </summary>
        /// <param name="blogPostIds">Areas identifiers</param>
        /// <returns>Areas</returns>
        IList<Area> GetAreasByIds(int[] areaIds);

        /// <summary>
        /// Gets an areas by poligon
        /// </summary>
        /// <param name="poligon">Poligon</param>
        /// <returns>Areas</returns>
        IList<Area> GetAreasByPoligon(object poligon);

        /// <summary>
        /// Delete area
        /// </summary>
        /// <param name="area">Area</param>
        void DeleteArea(Area area);

        /// <summary>
        /// Delete area by identifier
        /// </summary>
        /// <param name="areaId">Area identifier</param>
        void DeleteAreaById(int areaId);

        /// <summary>
        /// Inserts an area
        /// </summary>
        /// <param name="area">Area</param>
        void InsertArea(Area area);

        /// <summary>
        /// Updates the area
        /// </summary>
        /// <param name="area">Area</param>
        void UpdateArea(Area area);

        /// <summary>
        /// Get area document by area identifier
        /// </summary>
        /// <param name="areaId">Area identifier</param>
        /// <returns>Area document</returns>
        AreaDocument GetAreaDocumentById(int areaId);

        /// <summary>
        /// Get all area types
        /// </summary>
        /// <returns>Area types</returns>
        IList<AreaType> GetAreaTypesAll();

        /// <summary>
        /// Get all area ownership types
        /// </summary>
        /// <returns>Area ownership types</returns>
        IList<AreaOwnershipType> GetAreaOwnershipTypesAll();
    }
}
