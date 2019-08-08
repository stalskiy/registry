using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Registry.Web.Extensions;
using Registry.Web.Models;

namespace Registry.Web.Controllers
{
    /// <summary>
    /// Area controller
    /// </summary>
    public class AreaController : Controller
    {
        ////TODO: Need to integrate with API! + Library RestSharp
        static List<AreaModel> areas = new List<AreaModel>();
        static List<PolygonModel> polygons = new List<PolygonModel>();

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

        /// <summary>
        /// Insert area
        /// </summary>
        /// <param name="values">Area values</param>
        /// <returns>Insert result</returns>
        [HttpPost]
        public IActionResult InsertArea(string values)
        {
            var newArea = new AreaModel();
            JsonConvert.PopulateObject(values, newArea);

            if (!TryValidateModel(newArea))
                return BadRequest(ModelState.GetFullErrorMessage());
            newArea.Id = areas.Any() ? areas.Max(t => t.Id) + 1 : 1;

            newArea.FileName = GetFileDetailById(newArea.FileId)?.Name;

            areas.Add(newArea);

            return Ok(newArea);
        }

        /// <summary>
        /// Update area
        /// </summary>
        /// <param name="key">Area key</param>
        /// <param name="values">Area values</param>
        /// <returns>Update result</returns>
        [HttpPut]
        public IActionResult UpdateArea(int key, string values)
        {
            var area = areas.Where(t => t.Id == key).FirstOrDefault();
            JsonConvert.PopulateObject(values, area);

            area.FileName = GetFileDetailById(area.FileId)?.Name;

            return Ok(area);
        }

        /// <summary>
        /// Delete area
        /// </summary>
        /// <param name="key">Area key</param>
        [HttpDelete]
        public void DeleteArea(int key)
        {
            var area = areas.Where(t => t.Id == key).FirstOrDefault();

            areas.RemoveAll(t => t.Id == key);
            polygons.RemoveAll(t => t.AreaId == key);

            if (area != null)
                FileController.Files.RemoveAll(t => t.Id == area.FileId);
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
                new AreaTypeModel() { Id = 1, Name = "Земельный участок" },
                new AreaTypeModel() { Id = 2, Name = "Единое землепользование" },
                new AreaTypeModel() { Id = 3, Name = "Часть земельного участка" }
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
                new AreaOwnershipTypeModel() { Id = 1, Name = "Собственность" },
                new AreaOwnershipTypeModel() { Id = 2, Name = "Пожизненное наследуемое владение" },
                new AreaOwnershipTypeModel() { Id = 3, Name = "Постоянное (бессрочное)пользование" },
                new AreaOwnershipTypeModel() { Id = 4, Name = "Аренда" },
                new AreaOwnershipTypeModel() { Id = 5, Name = "Оперативное управление" }
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

        /// <summary>
        /// Insert polygon
        /// </summary>
        /// <param name="values">Polygon values</param>
        /// <returns>Insert result</returns>
        [HttpPost]
        public IActionResult InsertPolygon(string values)
        {
            var newPolygon = new PolygonModel();
            JsonConvert.PopulateObject(values, newPolygon);

            if (!TryValidateModel(newPolygon))
                return BadRequest(ModelState.GetFullErrorMessage());
            polygons.Add(newPolygon);

            return Ok(newPolygon);
        }

        /// <summary>
        /// Get file detail by id
        /// </summary>
        /// <param name="id">File identifier</param>
        /// <returns>File detail</returns>
        public FileDetailModel GetFileDetailById(int id)
        {
            var file = FileController.Files.Where(t => t.Id == id).FirstOrDefault();

            if (file == null)
                return null;

            return new FileDetailModel() { Id = file.Id, DateCreate = file.DateCreate, Name = file.File.FileName };
        }

        #endregion
    }
}