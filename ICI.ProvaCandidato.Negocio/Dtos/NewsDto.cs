using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Negocio.Dtos
{
    public class NewsDto
    {
        public int Id { get; set; }

        [Required()]
        [StringLength(250)]
        public string Title { get; set; }

        [Required()]
        public string Text { get; set; }

        public int UserId { get; set; }

        public UserDto User { get; set; }

        public ICollection<TagNewsDto> TagNews { get; set; } = new List<TagNewsDto>();

        public List<int> SelectedTagIds { get; set; }
    }
}
