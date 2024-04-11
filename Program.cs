using ElephantSQL.db;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My ElephantSQL API", Version = "v1" });
});


// ElephantSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ElephantSQL")));


// Adicionando o servi�o de API Explorer Endpoints
builder.Services.AddEndpointsApiExplorer();


// Adicionando o servi�o de Controllers
builder.Services.AddControllers();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My ElephantSQL API V1"));
}

// Use HTTPS redirection in production for enhanced security.
app.UseHttpsRedirection();

// Mapeamento dos controladores
app.MapControllers();

// Start the application
app.Run();
