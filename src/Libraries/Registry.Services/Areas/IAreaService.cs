using Registry.Core.Domain.Areas;
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
        /// Marks area as deleted 
        /// </summary>
        /// <param name="area">Area</param>
        void DeleteArea(Area area);

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
    }
}
