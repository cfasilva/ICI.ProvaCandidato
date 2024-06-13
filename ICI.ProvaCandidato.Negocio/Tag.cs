using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Negocio
{
    public class Tag
    {
        public int Id { get; set; }
        [Required()]
        [StringLength(100)]
        public string Description { get; set; }
        public ICollection<TagNews> TagNews { get; set; }
    }
}
