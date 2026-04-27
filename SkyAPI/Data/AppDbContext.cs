using Microsoft.EntityFrameworkCore;
using SkyAPI.Models;

namespace SkyAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<Comentario> Comentarios { get; set; }
}
