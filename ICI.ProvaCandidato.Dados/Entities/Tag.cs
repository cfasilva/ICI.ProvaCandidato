using System.Collections.Generic;

namespace ICI.ProvaCandidato.Dados.Entities
{
    public class Tag
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public ICollection<TagNews> TagNews { get; set; } = new List<TagNews>();
    }
}
