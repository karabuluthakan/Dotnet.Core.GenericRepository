using System;
using System.Linq;
using Dotnet.Core.Common.Contracts;
using Dotnet.Core.Common.Helpers.Extensions;
using Dotnet.Core.DataAccess.Abstract.EntityFramework;
using Dotnet.Core.Entities.Geolocation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

            builder.GeolocationSeeding();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            try
            {
                var modifiedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).ToList();
                var now = System.DateTime.UtcNow;

                foreach (var change in modifiedEntities)
                {
                    var entityName = change.Entity.GetType().Name;

                    var primaryKey = change.OriginalValues.Properties.FirstOrDefault(x => x.IsPrimaryKey() == true).Name;

                    foreach (IProperty property in change.OriginalValues.Properties)
                    {
                        var originalValue = change.OriginalValues[property.Name].ToString();
                        var currentValue = change.CurrentValues[property.Name].ToString();

                        if (originalValue!=currentValue)
                        {
                            ChangeLog changeLog = new ChangeLog()
                            {
                                EntityName = entityName,
                                PrimaryKeyValue = int.Parse(change.OriginalValues[primaryKey].ToString()),
                                PropertyName = property.Name,
                                OldValue = originalValue,
                                NewValue = currentValue,
                                DateChanged = now,
                                State = EnumState.Update
                            };
                            
                           // ElasticSearch.CheckExistsAndInsert(changeLog);
                        }
                    }
                }

                return base.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public DbSet<Continental> Continentals { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}