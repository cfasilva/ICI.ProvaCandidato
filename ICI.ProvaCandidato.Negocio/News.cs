﻿namespace ICI.ProvaCandidato.Negocio
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public virtual User User { get; set; }
    }
}
