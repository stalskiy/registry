using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registry.Core.Domain.Areas;
using Registry.Core.Domain.References;

namespace Registry.Data.Mapping.References
{
    /// <summary>
    /// Represents an area type mapping configuration
    /// </summary>
    public partial class AreaTypeMap : EntityTypeConfiguration<AreaType>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<AreaType> builder)
        {
            builder.ToTable(nameof(AreaType));
            builder.HasKey(area => area.Id);

            builder.Property(area => area.Name).IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}
