using Registry.Core.Data;
using Registry.Core.Domain.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Registry.Services.Areas
{
    /// <summary>
    /// Area service
    /// </summary>
    public partial class AreaService : IAreaService
    {
        #region Fields
        
        private readonly IRepository<Area> _areaRepository;

        #endregion

        #region Ctor

        public AreaService(IRepository<Area> areaRepository)
        {
            _areaRepository = areaRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets area by area identifier
        /// </summary>
        /// <param name="areaId">Area identifier</param>
        /// <returns>Area</returns>
        public Area GetAreaById(int areaId)
        {
            if (areaId == 0)
                return null;

            return _areaRepository.GetById(areaId);
        }

        /// <summary>
        /// Gets all areas
        /// </summary>
        /// <returns>Areas</returns>
        public IList<Area> GetAreasAll()
        {
            var query = _areaRepository.Table;
            return query.ToList();
        }

        /// <summary>
        /// Gets areas by areas identifiers
        /// </summary>
        /// <param name="blogPostIds">Areas identifiers</param>
        /// <returns>Areas</returns>
        public IList<Area> GetAreasByIds(int[] areaIds)
        {
            var query = _areaRepository.Table;
            return query.Where(area => areaIds.Contains(area.Id)).ToList();
        }

        /// <summary>
        /// Gets an areas by poligon
        /// </summary>
        /// <param name="poligon">Poligon</param>
        /// <returns>Areas</returns>
        public IList<Area> GetAreasByPoligon(object poligon)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Marks area as deleted 
        /// </summary>
        /// <param name="area">Area</param>
        public void DeleteArea(Area area)
        {
            if (area == null)
                throw new ArgumentNullException(nameof(area));

            _areaRepository.Delete(area);
        }

        /// <summary>
        /// Inserts an area
        /// </summary>
        /// <param name="area">Area</param>
        public void InsertArea(Area area)
        {
            if (area == null)
                throw new ArgumentNullException(nameof(area));

            _areaRepository.Insert(area);
        }

        /// <summary>
        /// Updates the area
        /// </summary>
        /// <param name="area">Area</param>
        public void UpdateArea(Area area)
        {
            if (area == null)
                throw new ArgumentNullException(nameof(area));

            _areaRepository.Update(area);

        }
        #endregion
    }
}
