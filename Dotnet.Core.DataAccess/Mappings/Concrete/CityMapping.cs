using Dotnet.Core.DataAccess.Mappings.Abstract;
using Dotnet.Core.Entities.Geolocation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnet.Core.DataAccess.Mappings.Concrete
{
    public class CityMapping : EntitySimpleMapping<int, City>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("cities");

            builder.Property(x => x.CountryId).HasColumnName("country_id").IsRequired();

            builder.HasOne(x => x.Country)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.CountryId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}