using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Negocio.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required()]
        [StringLength(250)]
        public string Name { get; set; }

        [Required()]
        [StringLength(250)]
        [EmailAddress]
        public string Email { get; set; }

        [Required()]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
