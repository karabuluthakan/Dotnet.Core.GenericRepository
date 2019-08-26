using Dotnet.Core.Common.Helpers.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Dotnet.Core.DataAccess.Context
{
    public class GenericContext : DbContext
    {
        public GenericContext(DbContextOptions<GenericContext> options) : base(options)
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
    }
}