using AutoMapper;
using Dotnet.Core.Common.Entities.Dto;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Entities.Dto.V1.ListDtos
{
    public class RegionForListDto : IEntityDto, IHaveCustomMapping
    {
        public string Name { get; set; }
        public string ContinentalName { get; set; }

        public void CreateMappings(Profile conf)
        {
            conf.CreateMap<Region, RegionForListDto>().ReverseMap();
        }
    }
}