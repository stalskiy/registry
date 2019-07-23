using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registry.Core.Domain.Areas;

namespace Registry.Data.Mapping.Areas
{
    /// <summary>
    /// Represents an area document mapping configuration
    /// </summary>
    public partial class AreaDocumentMap : EntityTypeConfiguration<AreaDocument>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<AreaDocument> builder)
        {
            builder.ToTable(nameof(AreaDocument));
            builder.HasKey(area => area.Id);

            builder.Property(area => area.File).IsRequired();
            builder.Property(area => area.ContentType).IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}
