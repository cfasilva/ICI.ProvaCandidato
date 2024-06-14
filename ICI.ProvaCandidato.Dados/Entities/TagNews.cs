namespace ICI.ProvaCandidato.Dados.Entities
{
    public class TagNews
    {
        public int Id { get; set; }

        public int TagId { get; set; }

        public int NewsId { get; set; }

        public virtual News News { get; set; }

        public virtual Tag Tag { get; set; }
    }
}