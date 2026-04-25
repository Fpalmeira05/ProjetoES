using System.Net.Http.Json;
using SkyAPI.DTOs;

namespace SkyAPI.Services;

public class TmdbService
{
    private readonly HttpClient _http;

    public TmdbService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<TmdbMovieDto>> PesquisarFilmesAsync(string titulo)
    {
        var resposta = await _http.GetFromJsonAsync<TmdbSearchResponse>(
            $"search/movie?query={Uri.EscapeDataString(titulo)}&language=pt-PT"
        );

        return resposta?.Results ?? new List<TmdbMovieDto>();
    }
}
