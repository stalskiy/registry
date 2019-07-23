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
    /// Area document controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AreaDocumentController : ControllerBase
    {
        #region Fields

        private IAreaService _areaService;

        #endregion

        #region Ctors

        /// <summary>
        /// Area document controller
        /// </summary>
        /// <param name="areaService">Area service</param>
        public AreaDocumentController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        #endregion

        // GET api/values
        /// <summary>
        /// Get area document by area identifier
        /// </summary>
        /// <returns>Area document</returns>
        [HttpGet("{id}")]
        public FileResult Get(int id)
        {
            var document = _areaService.GetAreaDocumentById(id);
            return File(document.File, document.ContentType);
        }
    }
}