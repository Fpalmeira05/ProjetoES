using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyAPI.Data;
using SkyAPI.Models;

namespace SkyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmesController : ControllerBase
{
    private readonly AppDbContext _context;

    public FilmesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Filme>>> GetFilmes()
    {
        return await _context.Filmes.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Filme>> CriarFilme(Filme filme)
    {
        _context.Filmes.Add(filme);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFilmes), new { id = filme.Id }, filme);
    }
}
