using AutoMapper;
using Dotnet.Core.Common.Entities.Dto;
using Dotnet.Core.Common.Enums;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Entities.Dto.V1.CreateDtos
{
    public class CityForCreateDto : IEntityDto, IHaveCustomMapping
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public StatusEnum Status { get; set; }

        public void CreateMappings(Profile conf)
        {
            conf.CreateMap<City, CityForCreateDto>().ReverseMap();
        }
    }
}