var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NewDbContext>(options =>
        options.UseSqlServer(Settings.ConnectionString))
    .AddScoped<ICompanyRepository, CompanyRepository>()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();
var app = builder.Build();
app.UseSwagger()
    .UseSwaggerUI()
    .UseHttpsRedirection();
SetMappings(app).Run();

static WebApplication SetMappings(WebApplication application)
{
    application.MapGet("/department", async (ICompanyRepository company) =>
        JsonSerializer.Serialize(await company.GetDepartmentAsync(), Settings.SerializerOptions));
    application.MapPut("createuser", async (UserModel user, ICompanyRepository company) =>
        await company.CreateUserAsync(user) ? Results.Ok(user) : Results.BadRequest(user));
    application.MapGet("readuser", async (int id, ICompanyRepository company) =>
    {
        var user = await company.ReadUserAsync(id);
        return user is not null ? Results.Ok(user) : Results.NotFound(id);
    });
    application.MapPatch("updateuser", async (UserModel user, ICompanyRepository company) =>
        Results.Created($"https://localhost/readuser?id={user.Id}", await company.UpdateUserAsync(user)));
    application.MapDelete("deleteuser", async (int id, ICompanyRepository company) =>
        Results.Ok(await company.DeleteUserAsync(id)));
    return application;
}