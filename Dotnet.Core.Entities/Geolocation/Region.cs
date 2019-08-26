using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Dotnet.Core.Common.Entities;

namespace Dotnet.Core.Entities.Geolocation
{
    [Table("regions")]
    public class Region : EntitySimple<int>
    {
        [Column("continental_id", Order = 1)] public int ContinentalId { get; set; }
        [ForeignKey(nameof(ContinentalId))] public virtual Continental Continental { get; set; }

        [InverseProperty("Region")] public ICollection<Country> Countries { get; set; }
    }
}