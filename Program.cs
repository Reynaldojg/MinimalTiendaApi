using Microsoft.EntityFrameworkCore;
using TiendaApi.Data;
using TiendaApi.Repository;
using TiendaApi.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

//1) Servicios(contenedor  de dependencias)
builder.Services.AddOpenApi();
builder.Services.AddValidation();
//Conexion a la BDD
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("")));
//Agregando los Scoped para cuadno se haga la peticion llegue al repository
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddProblemDetails();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
