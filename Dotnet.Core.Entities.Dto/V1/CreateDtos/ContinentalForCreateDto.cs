using AutoMapper;
using Dotnet.Core.Common.Entities.Dto;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Entities.Dto.V1.CreateDtos
{
    public class ContinentalForCreateDto : IEntityDto, IHaveCustomMapping
    {
        public string Name { get; set; }

        public void CreateMappings(Profile conf)
        {
            conf.CreateMap<Continental, ContinentalForCreateDto>().ReverseMap();
        }
    }
}