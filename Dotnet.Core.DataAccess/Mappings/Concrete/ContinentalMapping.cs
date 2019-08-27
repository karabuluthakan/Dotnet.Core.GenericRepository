using Dotnet.Core.Common.DataAccess.Mappings;
using Dotnet.Core.Entities.Geolocation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnet.Core.DataAccess.Mappings.Concrete
{
    public class ContinentalMapping : EntitySimpleMapping<int, Continental>
    {
        public override void Configure(EntityTypeBuilder<Continental> builder)
        {
            builder.ToTable("continentals");
            base.Configure(builder);
        }
    }
}