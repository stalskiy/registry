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
    /// Area type controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AreaTypeController : ControllerBase
    {
        #region Fields

        private IAreaService _areaService;

        #endregion

        #region Ctors

        /// <summary>
        /// Area type controller
        /// </summary>
        /// <param name="areaService">Area service</param>
        public AreaTypeController(IAreaService areaService)
        {
            _areaService = areaService;
        }  

        #endregion

        // GET api/values
        /// <summary>
        /// Get all area types
        /// </summary>
        /// <returns>Area types</returns>
        [HttpGet]
        public ActionResult<IEnumerable<AreaType>> Get()
        {
            return _areaService.GetAreaTypesAll()
                .ToArray();
        }
    }
}