using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registry.Core.Domain.Areas;
using Registry.Services.Areas;

namespace Registry.Api.Controllers
{
    /// <summary>
    /// Area controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        #region Fields

        private IAreaService _areaService;

        #endregion

        #region Ctors

        /// <summary>
        /// Area controller
        /// </summary>
        /// <param name="areaService">Area service</param>
        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }  

        #endregion

        // GET api/values
        /// <summary>
        /// Get all areas
        /// </summary>
        /// <returns>Areas</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Area>> Get()
        {
            return _areaService.GetAreasAll()
                .ToArray();
        }

        // GET api/values/5
        /// <summary>
        /// Get area by identifier
        /// </summary>
        /// <param name="id">Area identifier</param>
        /// <returns>Area</returns>
        [HttpGet("{id}")]
        public ActionResult<Area> Get(int id)
        {
            return _areaService.GetAreaById(id);
        }

        // POST api/values
        /// <summary>
        /// Create new area
        /// </summary>
        /// <param name="value">Area</param>
        [HttpPost]
        public void Post([FromBody] Area value)
        {
            _areaService.InsertArea(value);
        }

        // PUT api/values/5
        /// <summary>
        /// Update area
        /// </summary>
        /// <param name="value">Area</param>
        [HttpPut]
        public void Put([FromBody] Area value)
        {
            _areaService.InsertArea(value);
        }

        // DELETE api/values/5
        /// <summary>
        /// Delete area by id
        /// </summary>
        /// <param name="id">Area identifier</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _areaService.DeleteAreaById(id);
        }
    }
}