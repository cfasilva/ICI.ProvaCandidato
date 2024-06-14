using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICI.ProvaCandidato.Dados.Entities;

namespace ICI.ProvaCandidato.Negocio.Dtos
{
    public class TagDto
    {
        public int Id { get; set; }

        [Required()]
        [StringLength(100)]
        public string Description { get; set; }

        public ICollection<TagNewsDto> TagNews { get; set; } = new List<TagNewsDto>();
    }
}
