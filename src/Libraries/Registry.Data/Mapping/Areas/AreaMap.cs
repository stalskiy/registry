using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registry.Core.Domain.Areas;

namespace Registry.Data.Mapping.Areas
{
    /// <summary>
    /// Represents an area mapping configuration
    /// </summary>
    public partial class AreaMap : EntityTypeConfiguration<Area>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable(nameof(Area));
            builder.HasKey(area => area.Id);

            builder.Property(area => area.Name).IsRequired();
            builder.Property(area => area.CadastralNum).IsRequired();

            builder.HasOne(area => area.AreaType)
                .WithMany()
                .HasForeignKey(area => area.AreaTypeId);

            builder.HasOne(area => area.OwnershipType)
                .WithMany()
                .HasForeignKey(area => area.OwnershipTypeId);

            base.Configure(builder);
        }

        #endregion
    }
}
