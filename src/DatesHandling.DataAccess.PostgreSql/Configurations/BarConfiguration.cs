using DatesHandling.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatesHandling.DataAccess.PostgreSql.Configurations
{
    internal class BarConfiguration : IEntityTypeConfiguration<Bar>
    {
        public void Configure(EntityTypeBuilder<Bar> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Timestamptz)
                .HasColumnType("timestamptz")
                .IsRequired(true);
        }
    }
}
