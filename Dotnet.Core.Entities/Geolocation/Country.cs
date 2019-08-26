using System.ComponentModel.DataAnnotations.Schema;
using Dotnet.Core.Common.Entities;

namespace Dotnet.Core.Entities.Geolocation
{
    [Table("countries")]
    public class Country : EntitySimple<int>
    {
        [Column("region_id", Order = 1)] public int RegionId { get; set; }
        [ForeignKey(nameof(RegionId))] public virtual Region Region { get; set; }

        [Column("alpha_2_code", TypeName = "varchar(2)")]
        public string Alpha2Code { get; set; }

        [Column("alpha_3_code", TypeName = "varchar(3)")]
        public string Alpha3Code { get; set; }
        [Column("un_code",TypeName = "varchar(3)")] public string UNCode { get; set; }
    }
}