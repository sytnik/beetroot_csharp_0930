using System.Text.Json;
using System.Text.Json.Serialization;
using Lesson34.DAO;
using Lesson34.Service;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NewDbContext>(options =>
    options.UseSqlServer(new SqlConnectionStringBuilder
    {
        DataSource = "127.0.0.1", InitialCatalog = "newdb",
        UserID = "sa", Password = "sa/ics5603", TrustServerCertificate = true
    }.ConnectionString));

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

var options = new JsonSerializerOptions()
{
    ReferenceHandler = ReferenceHandler.Preserve
};

app.MapGet("/department", async (ICompanyRepository company) =>
        Results.Ok(JsonSerializer.Serialize(await company.GetDepartmentAsync(), options)))
    .WithName("GetDepartment")
    .WithOpenApi();

app.MapPost("adduser", async (User user, ICompanyRepository company) =>
{
    await company.AddUserAsync(user);
    return Results.Created($"/users/{user.Id}", user);
});

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
}