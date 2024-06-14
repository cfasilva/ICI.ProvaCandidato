namespace ICI.ProvaCandidato.Negocio.Dtos
{
    public class TagNewsDto
    {
        public int Id { get; set; }

        public int TagId { get; set; }

        public int NewsId { get; set; }

        public NewsDto News { get; set; }

        public TagDto Tag { get; set; }
    }
}
