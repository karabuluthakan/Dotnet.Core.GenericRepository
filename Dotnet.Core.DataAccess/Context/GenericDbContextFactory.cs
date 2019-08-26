using Microsoft.EntityFrameworkCore;

namespace Dotnet.Core.DataAccess.Context
{
    public class GenericDbContextFactory: DesignTimeDbContextFactoryBase<GenericContext>
    {
        protected override GenericContext CreateNewInstance(DbContextOptions<GenericContext> options)
        {
            return new GenericContext(options);
        }
    }
}