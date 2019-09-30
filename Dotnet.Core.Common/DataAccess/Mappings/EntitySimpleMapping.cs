using Dotnet.Core.Common.Entities;
using Dotnet.Core.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnet.Core.Common.DataAccess.Mappings
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

            builder.Property(x => x.Status).HasColumnName("status")
                .HasConversion<int>()
                .HasMaxLength(1)
                .HasDefaultValue(StatusEnum.Active)
                .IsRequired()
                .ForNpgsqlHasComment("Active=1(Default),Passive=2,Hold=3,Done=4,Deleted=5");
        }
    }
}