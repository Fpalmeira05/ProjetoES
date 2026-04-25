using Microsoft.AspNetCore.Mvc;
using SkyAPI.Services;

namespace SkyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TmdbController : ControllerBase
{
    private readonly TmdbService _tmdbService;

    public TmdbController(TmdbService tmdbService)
    {
        _tmdbService = tmdbService;
    }

    [HttpGet("pesquisar")]
    public async Task<IActionResult> Pesquisar([FromQuery] string titulo)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            return BadRequest("O título é obrigatório.");

        var filmes = await _tmdbService.PesquisarFilmesAsync(titulo);

        return Ok(filmes);
    }
}
