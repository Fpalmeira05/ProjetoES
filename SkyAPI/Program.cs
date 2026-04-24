var builder = WebApplication.CreateBuilder(args);

// --- 1. ADICIONAR ISTO: Configurar o CORS ---
// Diz à API que o teu frontend (na porta 5129) é um amigo de confiança e pode entrar
builder.Services.AddCors(options => {
    options.AddPolicy("BlazorClient", policy =>
        policy.WithOrigins("http://localhost:5129") 
              .AllowAnyMethod()
              .AllowAnyHeader());
});
// ---------------------------------------------

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// --- 2. ADICIONAR ISTO: Ativar o CORS ---
// MUITO IMPORTANTE: Tem de ficar aqui em cima, antes do app.MapControllers()
app.UseCors("BlazorClient");
// ----------------------------------------

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
