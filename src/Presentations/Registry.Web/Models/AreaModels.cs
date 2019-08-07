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

        [Required(ErrorMessage = "Model.Area.Required.Name")]
        //[Display(Name = "Model.Area.Display.Name")]
        public string Name { get; set; }

        //[Display(Name = "Model.Area.Display.InventoryNum")]
        public string InventoryNum { get; set; }

        [Required(ErrorMessage = "Model.Area.Required.CadastralNum")]
        //[Display(Name = "Model.Area.Display.CadastralNum")]
        public string CadastralNum { get; set; }

        //[Display(Name = "Model.Area.Display.AreaTypeId")]
        public int? AreaTypeId { get; set; }

        //[Display(Name = "Model.Area.Display.AreaType")]
        public string AreaType { get; set; }

        //[Display(Name = "Model.Area.Display.AreaOwnershipTypeId")]
        public int? AreaOwnershipTypeId { get; set; }

        //[Display(Name = "Model.Area.Display.AreaOwnershipType")]
        public string AreaOwnershipType { get; set; }
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
