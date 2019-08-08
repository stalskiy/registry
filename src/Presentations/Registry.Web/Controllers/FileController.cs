using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Registry.Web.Models;

namespace Registry.Web.Controllers
{

    /// <summary>
    /// File controller
    /// </summary>
    public class FileController : Controller
    {
        public static List<FileModel> Files = new List<FileModel>();

        #region Methods

        /// <summary>
        /// Upload file
        /// </summary>
        /// <returns>Upload result</returns>
        [HttpPost]
        public ActionResult Upload()
        {
            var fileId = Files.Any() ? Files.Max(t => t.Id) + 1 : 1;

            FileModel file = new FileModel()
            {
                Id = fileId,
                DateCreate = DateTime.Now
            };

            try
            {
                file.File = Request.Form.Files["File"];
                using (var fileStram = file.File.OpenReadStream())
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        fileStram.CopyTo(ms);
                        file.Data = ms.ToArray();
                    }
                }

                Files.Add(file);
            }
            catch
            {
                Response.StatusCode = 400;
            }

            return Ok(fileId);
        }

        /// <summary>
        /// Download file
        /// </summary>
        /// <param name="id">File identifier</param>
        /// <returns>File</returns>
        [HttpGet]
        public FileResult Download(int id)
        {
            var fileDetail = Files.Where(t => t.Id == id).FirstOrDefault();
            var file = fileDetail.File;

            if (file != null)
            {
                return File(fileDetail.Data, file.ContentType, file.FileName);
            }
            else
                return null;
        }

        #endregion
    }
}