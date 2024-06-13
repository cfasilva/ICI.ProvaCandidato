using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Negocio
{
    public class News
    {
        public int Id { get; set; }
        [Required()]
        [StringLength(250)]
        public string Title { get; set; }
        [Required()]
        public string Text { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<TagNews> TagNews { get; set; }
    }
}
