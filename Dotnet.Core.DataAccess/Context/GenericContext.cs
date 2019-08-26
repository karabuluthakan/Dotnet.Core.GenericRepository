using Dotnet.Core.Common.Helpers.Extensions;
using Dotnet.Core.Entities.Geolocation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Dotnet.Core.DataAccess.Context
{
    public class GenericContext : DbContext, IEntityDbContext
    {
        public GenericContext(DbContextOptions<GenericContext> options) : base(options)
        {
        }

        public GenericContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("public");
            builder.ForNpgsqlUseIdentityColumns();
            builder.LowerCaseTablesAndFields();
            builder.DisableCascadingDeletes();

            builder.ApplyConfigurationsFromAssembly(typeof(GenericContext).Assembly);
        }

        public DbSet<Continental> Continentals { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}