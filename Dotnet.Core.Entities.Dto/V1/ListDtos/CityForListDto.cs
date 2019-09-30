using AutoMapper;
using Dotnet.Core.Common.Entities.Dto;
using Dotnet.Core.Common.Enums;

namespace Dotnet.Core.Entities.Dto.V1.ListDtos
{
    public class CityForListDto: IEntityDto, IHaveCustomMapping
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int RegionId { get; set; }
        public int ContinentalId { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string RegionName { get; set; }
        public string ContinentalName { get; set; }
        public void CreateMappings(Profile conf)
        {
            throw new System.NotImplementedException();
        }

        public StatusEnum Status { get; set; }
    }
}