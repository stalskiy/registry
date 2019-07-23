using Registry.Core.Data;
using Registry.Core.Domain.Areas;
using Registry.Core.Domain.References;
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
        private readonly IRepository<AreaType> _areaTypeRepository;
        private readonly IRepository<AreaOwnershipType> _areaOwnershipTypeRepository;

        #endregion

        #region Ctor

        /// <summary>
        /// Area service
        /// </summary>
        public AreaService(IRepository<Area> areaRepository,
            IRepository<AreaType> areaTypeRepository, 
            IRepository<AreaOwnershipType> areaOwnershipTypeRepository)
        {
            _areaRepository = areaRepository;
            _areaTypeRepository = areaTypeRepository;
            _areaOwnershipTypeRepository = areaOwnershipTypeRepository;
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
        /// Delete area
        /// </summary>
        /// <param name="area">Area</param>
        public void DeleteArea(Area area)
        {
            if (area == null)
                throw new ArgumentNullException(nameof(area));

            _areaRepository.Delete(area);
        }

        /// <summary>
        /// Delete area by identifier
        /// </summary>
        /// <param name="areaId">Area identifier</param>
        public void DeleteAreaById(int areaId)
        {
            if (areaId == 0)
                return;

            Area area = new Area() { Id = areaId };

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

        /// <summary>
        /// Get area document by area identifier
        /// </summary>
        /// <param name="areaId">Area identifier</param>
        /// <returns>Are document</returns>
        public AreaDocument GetAreaDocumentById(int areaId)
        {
            if (areaId == 0)
                return null;

            var query = _areaRepository.Table;
            return query.Where(t => t.Id == areaId).FirstOrDefault()?.Document;
        }

        /// <summary>
        /// Get all area types
        /// </summary>
        /// <returns>Area types</returns>
        public IList<AreaType> GetAreaTypesAll()
        {
            var query = _areaTypeRepository.Table;
            return query.ToList();
        }

        /// <summary>
        /// Get all area ownership types
        /// </summary>
        /// <returns>Area ownership types</returns>
        public IList<AreaOwnershipType> GetAreaOwnershipTypesAll()
        {
            var query = _areaOwnershipTypeRepository.Table;
            return query.ToList();
        }
        #endregion
    }
}
