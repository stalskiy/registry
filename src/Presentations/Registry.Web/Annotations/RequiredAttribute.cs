using Registry.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registry.Web.Annotations
{
    /// <summary>
    /// Required attribute
    /// </summary>
    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        /// <summary>
        /// Error message
        /// </summary>
        public new string ErrorMessage
        {
            get { return base.ErrorMessage; }
            set { base.ErrorMessage.Localize(); }
        }
    }
}
