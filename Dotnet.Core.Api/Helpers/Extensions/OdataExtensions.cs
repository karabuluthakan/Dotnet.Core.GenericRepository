using System;
using Dotnet.Core.Entities.Geolocation;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;

namespace Dotnet.Core.Api.Helpers.Extensions
{
    public class OdataExtensions
    {
        public IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);
            builder.EntitySet<Continental>("Continentals")
                .EntityType
                .Filter()
                .Count()
                .Expand(4)
                .OrderBy()
                .Page()
                .Select()
                .ContainsMany(x => x.Regions)
                .Expand();


            builder.EntitySet<Region>("Regions")
                .EntityType
                .Filter()
                .Count()
                .Expand(3)
                .OrderBy()
                .Page()
                .Select()
                .ContainsMany(x => x.Countries)
                .Expand();


            builder.EntitySet<Country>("Countries")
                .EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select()
                .ContainsMany(x => x.Cities)
                .Expand();

            builder.EntitySet<City>("Cities")
                .EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select();

            return builder.GetEdmModel();
        }
    }
}