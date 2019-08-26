using Dotnet.Core.DataAccess.Mappings.Abstract;
using Dotnet.Core.Entities.Geolocation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnet.Core.DataAccess.Mappings.Concrete
{
    public class CountryMapping : EntitySimpleMapping<int, Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("countries");

            builder.Property(x => x.RegionId).IsRequired().HasColumnName("region_id");
            builder.Property(x => x.Alpha2Code).IsRequired().HasColumnName("alpha_2_code").HasColumnType("varchar")
                .HasMaxLength(2);
            builder.Property(x => x.Alpha3Code).IsRequired().HasColumnName("alpha_3_code").HasColumnType("varchar")
                .HasMaxLength(3);
            builder.Property(x => x.UNCode).IsRequired().HasColumnName("un_code").HasMaxLength(3);


            builder.HasOne(x => x.Region)
                .WithMany(x => x.Countries)
                .HasForeignKey(x => x.RegionId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}