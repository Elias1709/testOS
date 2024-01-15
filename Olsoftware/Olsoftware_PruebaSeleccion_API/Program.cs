using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Olsoftware_PruebaSeleccion_API;
using Olsoftware_PruebaSeleccion_API.Datos;
using Olsoftware_PruebaSeleccion_API.Modelos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Olsoftware_PruebaSeleccion_API", Version = "v1" });

    // Excluir tipos específicos
    options.MapType<APIResponse>(() => new OpenApiSchema { Type = "object" });
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseSqlServer(
                                builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingConfig));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
