using Microsoft.EntityFrameworkCore;
using SkyAPI.Data;
using SkyAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Base de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=skymedia.db")
);

// TMDB
builder.Services.AddHttpClient<TmdbService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Tmdb:BaseUrl"]!);
    client.DefaultRequestHeaders.Authorization =
        new System.Net.Http.Headers.AuthenticationHeaderValue(
            "Bearer",
            builder.Configuration["Tmdb:Token"]
        );
});

// CORS: permite chamadas vindas do Frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "BlazorClient",
        policy =>
        {
            policy.WithOrigins("http://localhost:5129").AllowAnyMethod().AllowAnyHeader();
        }
    );
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("BlazorClient");

app.UseAuthorization();

app.MapControllers();

app.Run();
