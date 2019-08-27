using Dotnet.Core.Common.DataAccess.Mappings;
using Dotnet.Core.Entities.Geolocation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnet.Core.DataAccess.Mappings.Concrete
{
    public class RegionMapping : EntitySimpleMapping<int, Region>
    {
        public override void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("regions");

            builder.Property(x => x.ContinentalId).IsRequired().HasColumnName("continental_id");

            builder.HasOne(x => x.Continental)
                .WithMany(x => x.Regions)
                .HasForeignKey(x => x.ContinentalId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}