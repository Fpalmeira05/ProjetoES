namespace SkyAPI.Models;

public class Filme
{
    public int Id { get; set; }

    public string Titulo { get; set; } = "";
    public string Sinopse { get; set; } = "";
    public string Genero { get; set; } = "";
    public string Realizador { get; set; } = "";

    public string PosterUrl { get; set; } = "";
    public string TrailerUrl { get; set; } = "";

    public double Popularidade { get; set; }
    public double ClassificacaoMedia { get; set; }
}
