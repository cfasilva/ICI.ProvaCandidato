namespace ICI.ProvaCandidato.Negocio
{
    public class TagNews
    {
        public int Id { get; set; }
        public virtual News News { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
