using AutoMapper;
using Dotnet.Core.Common.Entities.Dto;
using Dotnet.Core.Common.Enums;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Entities.Dto.V1.CreateDtos
{
    public class CountryForCreateDto : IEntityDto, IHaveCustomMapping
    {
        public string Name { get; set; }
        public int RegionId { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string UNCode { get; set; }
        public void CreateMappings(Profile conf)
        {
            conf.CreateMap<Country, CountryForCreateDto>().ReverseMap();
        }

        public StatusEnum Status { get; set; }
    }
}