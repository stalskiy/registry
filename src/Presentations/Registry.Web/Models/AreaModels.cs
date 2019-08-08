using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registry.Web.Models
{
    public class AreaModel: ModelBase
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string InventoryNum { get; set; }

        [Required]
        public string CadastralNum { get; set; }
        
        public int? AreaTypeId { get; set; }
        
        public string AreaType { get; set; }
        
        public int? AreaOwnershipTypeId { get; set; }
        
        public string AreaOwnershipType { get; set; }

        public int FileId { get; set; }

        public string FileName { get; set; }

        public FileDetailModel FileDetail { get; set; }
    }

    public class AreaTypeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class AreaOwnershipTypeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
