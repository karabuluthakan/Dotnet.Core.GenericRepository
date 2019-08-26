using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Dotnet.Core.Common.Entities;

namespace Dotnet.Core.Entities.Geolocation
{
    public class Continental : EntitySimple<int>
    {
        [InverseProperty("Continental")] public ICollection<Region> Regions { get; set; }
    }
}