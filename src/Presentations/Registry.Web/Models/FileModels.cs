using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registry.Web.Models
{
    public class FileModel
    {
        public int Id { get; set; }

        public byte[] Data { get; set; }

        public IFormFile File { get; set; }

        public DateTime DateCreate { get; set; }
    }

    public class FileDetailModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Size { get; set; }

        public DateTime DateCreate { get; set; }
    }
}
