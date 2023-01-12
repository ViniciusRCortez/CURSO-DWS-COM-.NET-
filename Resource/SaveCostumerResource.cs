using System.ComponentModel.DataAnnotations;

namespace Dws.Note_one.Api.Resource
{
    public class SaveCostumerResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public double Credit { get; set; }
    }
}