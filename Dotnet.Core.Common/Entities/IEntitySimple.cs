namespace Dotnet.Core.Common.Entities
{
    public interface IEntitySimple<T> : IBaseEntity<T>
    {
        string Name { get; set; }
    }
}