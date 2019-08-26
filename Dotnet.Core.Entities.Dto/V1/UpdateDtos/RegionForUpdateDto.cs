using AutoMapper;
using Dotnet.Core.Common.Entities.Dto;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Entities.Dto.V1.UpdateDtos
{
    public class RegionForUpdateDto : IEntityDto, IHaveCustomMapping
    {
        public string Name { get; set; }
        public int ContinentalId { get; set; }

        public void CreateMappings(Profile conf)
        {
            conf.CreateMap<Region, RegionForUpdateDto>().ReverseMap();
        }
    }
}