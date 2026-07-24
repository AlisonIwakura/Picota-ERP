using Microsoft.EntityFrameworkCore;
using Picota.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte aos Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Configuração do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexão com o banco de dados (usa o nome "Contexto" do appsettings.json)
builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("Contexto")));

// CORS: libera o front-end React (Vite) para acessar a API
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configuração do ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redireciona HTTP para HTTPS (comentado por enquanto, pois o front está usando HTTP)
// app.UseHttpsRedirection();

// Aplica a política de CORS (precisa vir ANTES de UseAuthorization/MapControllers)
app.UseCors("PermitirFrontend");

// Autorização
app.UseAuthorization();

// Mapeia os Controllers
app.MapControllers();

app.Run();