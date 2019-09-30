using AutoMapper;
using Dotnet.Core.Common.Entities.Dto;
using Dotnet.Core.Common.Enums;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Entities.Dto.V1.ListDtos
{
    public class CountryForListDto: IEntityDto, IHaveCustomMapping
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string RegionName { get; set; }
        public void CreateMappings(Profile conf)
        {
            conf.CreateMap<Country, CountryForListDto>().ReverseMap();
        }

        public StatusEnum Status { get; set; }
    }
}