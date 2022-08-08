using DatesHandling.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatesHandling.DataAccess.PostgreSql.Configurations
{
    internal class BazConfiguration : IEntityTypeConfiguration<Baz>
    {
        public void Configure(EntityTypeBuilder<Baz> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Date)
                .IsRequired(true);

            builder.Property(x => x.Time)
                .IsRequired(true);
        }
    }
}
