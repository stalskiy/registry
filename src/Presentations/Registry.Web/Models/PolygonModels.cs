using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registry.Web.Models
{
    /// <summary>
    /// Polygon model
    /// </summary>
    public class PolygonModel
    {
        public int AreaId { get; set; }

        public string Hint { get; set; }

        public object Coordinates { get; set; }
    }
}
