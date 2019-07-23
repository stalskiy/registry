using System;
using System.Collections.Generic;
using System.Text;

namespace Registry.Data
{
    /// <summary>
    /// Represents default values related to registry data
    /// </summary>
    public static partial class ApplicationDataDefaults
    {
        /// <summary>
        /// Gets a path to the file that contains script to add sample data
        /// </summary>
        public static string SqlServerDataSampleFilePath => "~/App_Data/Install/Data.Sample.sql";
    }
    
}
