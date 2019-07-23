using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registry.Core.Domain.Areas;
using Registry.Core.Domain.References;
using Registry.Services.Areas;

namespace Registry.Api.Controllers
{
    /// <summary>
    /// Area ownership type controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AreaOwnershipTypeController : ControllerBase
    {
        #region Fields

        private IAreaService _areaService;

        #endregion

        #region Ctors

        /// <summary>
        /// Area ownership type controller
        /// </summary>
        /// <param name="areaService">Area service</param>
        public AreaOwnershipTypeController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        #endregion

        // GET api/values
        /// <summary>
        /// Get all ownership types
        /// </summary>
        /// <returns>Area ownership types</returns>
        [HttpGet]
        public ActionResult<IEnumerable<AreaOwnershipType>> Get()
        {
            return _areaService.GetAreaOwnershipTypesAll()
                .ToArray();
        }
    }
}