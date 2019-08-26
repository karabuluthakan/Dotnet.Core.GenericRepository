using Dotnet.Core.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnet.Core.DataAccess.Mappings.Abstract
{
    public abstract class EntitySimpleMapping<TKey, TEntity> : IEntitySimpleMapping<TKey, TEntity>
        where TEntity : class, IEntitySimple<TKey>, new()
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.ForNpgsqlHasIndex(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(255)");

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}