using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registry.Core.Domain.Areas;
using Registry.Core.Domain.References;

namespace Registry.Data.Mapping.References
{
    /// <summary>
    /// Represents an area ownership type mapping configuration
    /// </summary>
    public partial class AreaOwnershipTypeMap : EntityTypeConfiguration<AreaOwnershipType>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<AreaOwnershipType> builder)
        {
            builder.ToTable(nameof(AreaOwnershipType));
            builder.HasKey(area => area.Id);

            builder.Property(area => area.Name).IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}
