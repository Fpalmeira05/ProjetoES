namespace SkyAPI.Models
{
    public class Comentario
    {
        public int Id {get; set;}
        public int FilmeId { get; set; }
        public Filme Filme {get; set;} // para obter os outros dados do filme
        public int UsuarioId { get; set; }
        public string Texto { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public bool Reportado { get; set; } = false; // para reportar comentários inapropriados
        public bool Visivel { get; set; } = true; // para ocultar comentários reportados

    }
}