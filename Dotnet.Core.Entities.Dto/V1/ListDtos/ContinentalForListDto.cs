using AutoMapper;
using Dotnet.Core.Common.Entities.Dto;
using Dotnet.Core.Common.Enums;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Entities.Dto.V1.ListDtos
{
    public class ContinentalForListDto: IEntityDto, IHaveCustomMapping
    {
        public string Name { get; set; }
        public void CreateMappings(Profile conf)
        {
            conf.CreateMap<Continental, ContinentalForListDto>().ReverseMap();
        }

        public StatusEnum Status { get; set; }
    }
}