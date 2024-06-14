using System.Collections.Generic;

namespace ICI.ProvaCandidato.Dados.Entities
{
    public class News
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public ICollection<TagNews> TagNews { get; set; } = new List<TagNews>();
    }
}