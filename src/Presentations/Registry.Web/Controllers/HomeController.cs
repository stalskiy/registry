using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Registry.Web.Models;

namespace Registry.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new AreaModel() { Id = 1, Name = "Moscow" });
        }

        [HttpGet]
        public object GetAreas(DataSourceLoadOptions loadOptions)
        {
            List<AreaModel> areas = new List<AreaModel>() {
                new AreaModel() { Id = 1, Name = "Moscow" },
                new AreaModel() { Id = 2, Name = "Derbent" }
                };

            return DataSourceLoader.Load(areas, loadOptions);
        }

        /// <summary>
        /// Get all area types
        /// </summary>
        /// <param name="loadOptions">DataSource load options</param>
        /// <returns>All area types</returns>
        [HttpGet]
        public object GetAreaTypes(DataSourceLoadOptions loadOptions)
        {
            List<AreaTypeModel> areas = new List<AreaTypeModel>() {
                new AreaTypeModel() { Id = 1, Name = "Moscow" },
                new AreaTypeModel() { Id = 2, Name = "Derbent" }
                };

            return DataSourceLoader.Load(areas, loadOptions);
        }

        /// <summary>
        /// Get all area ownership types
        /// </summary>
        /// <param name="loadOptions">DataSource load options</param>
        /// <returns>All area ownership types</returns>
        [HttpGet]
        public object GetAreaOwnershipTypes(DataSourceLoadOptions loadOptions)
        {
            List<AreaOwnershipTypeModel> areas = new List<AreaOwnershipTypeModel>() {
                new AreaOwnershipTypeModel() { Id = 1, Name = "Moscow" },
                new AreaOwnershipTypeModel() { Id = 2, Name = "Derbent" }
                };

            return DataSourceLoader.Load(areas, loadOptions);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
