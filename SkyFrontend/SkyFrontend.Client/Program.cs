using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient {
    BaseAddress = new Uri("http://localhost:5185") // <-- A porta da tua Web API
});

await builder.Build().RunAsync();
