using Dotnet.Core.Entities.Geolocation;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Core.DataAccess.Context
{
    public interface IEntityDbContext
    {
        DbSet<Continental> Continentals { get; set; }
        DbSet<Region> Regions { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<City> Cities { get; set; }
    }
}