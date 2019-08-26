using System.ComponentModel.DataAnnotations.Schema;
using Dotnet.Core.Common.Entities;

namespace Dotnet.Core.Entities.Geolocation
{
    [Table("cities")]
    public class City : EntitySimple<int>
    {
        [Column("country_id", Order = 1)] public int CountryId { get; set; }
        [ForeignKey(nameof(CountryId))] public virtual Country Country { get; set; }
    }
}