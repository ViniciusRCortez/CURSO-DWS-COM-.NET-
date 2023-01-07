using System.ComponentModel.DataAnnotations;
using Dws.Note_one.Api.Domain.Helpers;

namespace Dws.Note_one.Api.Resource
{
    public class SaveProductResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public short QuantityInPackage { get; set; }

        [Required]
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}