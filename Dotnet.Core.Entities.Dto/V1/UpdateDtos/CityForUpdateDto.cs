using AutoMapper;
using Dotnet.Core.Common.Entities.Dto;
using Dotnet.Core.Common.Enums;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Entities.Dto.V1.UpdateDtos
{
    public class CityForUpdateDto : IEntityDto, IHaveCustomMapping
    {
        public int CountryId { get; set; }
        public string Name { get; set; }

        public void CreateMappings(Profile conf)
        {
            conf.CreateMap<City, CityForUpdateDto>().ReverseMap();
        }

        public StatusEnum Status { get; set; }
    }
}