using AutoMapper;

namespace Dotnet.Core.Common.Entities.Dto
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile conf);
    }
}