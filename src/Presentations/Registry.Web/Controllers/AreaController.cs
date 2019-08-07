using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Registry.Web.Models;

namespace Registry.Web.Controllers
{
    /// <summary>
    /// Area controller
    /// </summary>
    public class AreaController : Controller
    {

        static List<AreaModel> areas = new List<AreaModel>() {
                new AreaModel() { Id = 1, Name = "Area loop", AreaTypeId = 1, AreaOwnershipTypeId = 1  },
                new AreaModel() { Id = 2, Name = "Area top", AreaTypeId = 2, AreaOwnershipTypeId = 2 }
                };

        static List<PolygonModel> polygons = new List<PolygonModel>() {
            new PolygonModel() { AreaId = 1, Coordinates = "[[[55.92236465487886,36.754001263671874],[55.58158491206362,36.5644871035156],[55.49748143686938,37.27310526757812],[55.92236465487886,36.754001263671874]]]" }
        };

        #region Methods

        /// <summary>
        /// Get all areas
        /// </summary>
        /// <param name="loadOptions">DataSource load options</param>
        /// <returns>All areas</returns>
        [HttpGet]
        public object GetAreas(DataSourceLoadOptions loadOptions)
        {

            return DataSourceLoader.Load(areas, loadOptions);
        }

        [HttpPost]
        public IActionResult InsertArea(string values)
        {
            var newArea = new AreaModel();
            JsonConvert.PopulateObject(values, newArea);

            //if (!TryValidateModel(newArea))
            //    return BadRequest(ModelState.GetFullErrorMessage());
            newArea.Id = areas.Any() ? areas.Max(t => t.Id) + 1 : 1;

            areas.Add(newArea);

            return Ok(newArea);
        }

        [HttpPut]
        public IActionResult UpdateArea(int key, string values)
        {
            var area = areas.Where(t => t.Id == key).FirstOrDefault();
            JsonConvert.PopulateObject(values, area);

            return Ok(area);
        }

        [HttpDelete]
        public void DeleteArea(int key)
        {
            areas.RemoveAll(t => t.Id == key);
            polygons.RemoveAll(t => t.AreaId == key);
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

        /// <summary>
        /// Get all polygons
        /// </summary>
        /// <param name="loadOptions">DataSource load options</param>
        /// <returns>All polygons</returns>
        [HttpGet]
        public object GetPolygons(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(polygons, loadOptions);
        }

        [HttpPost]
        public IActionResult InsertPolygon(string values)
        {
            var newPolygon = new PolygonModel();
            JsonConvert.PopulateObject(values, newPolygon);

            //if (!TryValidateModel(newArea))
            //    return BadRequest(ModelState.GetFullErrorMessage());
            polygons.Add(newPolygon);

            return Ok(newPolygon);
        }

        #endregion
    }
}