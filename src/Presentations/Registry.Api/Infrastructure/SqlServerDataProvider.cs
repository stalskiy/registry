using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Registry.Core.Data;
using Registry.Core.Infrastructure;
using Registry.Data;
using Registry.Data.Extensions;

namespace Registry.Api.Infrastructure
{
    public partial class SqlServerDataProvider : IDataProvider
    {
        #region Methods

        /// <summary>
        /// Initialize database
        /// </summary>

        public virtual void InitializeDatabase()
        {
            var context = EngineContext.Current.Resolve<IDbContext>();

            //create db
            var createDb = (context as DbContext).Database.EnsureCreated();
            if (!createDb)
                return;

            var fileProvider = EngineContext.Current.Resolve<IEngineFileProvider>();

            //create sample data
            context.ExecuteSqlScriptFromFile(fileProvider.MapPath(ApplicationDataDefaults.SqlServerDataSampleFilePath));
        }

        /// <summary>
        /// Get a support database parameter object (used by stored procedures)
        /// </summary>
        /// <returns>Parameter</returns>
        public virtual DbParameter GetParameter()
        {
            return new SqlParameter();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this data provider supports backup
        /// </summary>
        public virtual bool BackupSupported => true;

        /// <summary>
        /// Gets a maximum length of the data for HASHBYTES functions, returns 0 if HASHBYTES function is not supported
        /// </summary>
        public virtual int SupportedLengthOfBinaryHash => 8000; //для SQL Server 2008 и выше функция HASHBYTES имеет ограничение в 8000 символов.

        #endregion
    }
}
