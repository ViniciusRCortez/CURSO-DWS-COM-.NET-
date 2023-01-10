using System.ComponentModel.DataAnnotations;

namespace Dws.Note_one.Api.Resource
{
    public class AuthUserResource
    {
        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [MaxLength(10)]
        public string Password { get; set; }
    }
}