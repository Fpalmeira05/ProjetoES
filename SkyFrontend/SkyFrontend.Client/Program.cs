using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Isto permite que as páginas façam chamadas à API usando @inject HttpClient Http
builder.Services.AddScoped(sp => new HttpClient {
    BaseAddress = new Uri("https://localhost:5001") // Substitui 5001 pela porta onde a tua SkyAPI estiver a correr
});

await builder.Build().RunAsync();
