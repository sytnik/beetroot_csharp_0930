var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    ValidIssuer = HostAddress,
    ValidAudience = HostAddress,
    IssuerSigningKey = new SymmetricSecurityKey(JwtKey),
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = false,
    ValidateIssuerSigningKey = true
});
builder.Services.AddAuthorization();
builder.Services.AddDbContext<NewDbContext>(options =>
        options.UseSqlServer(ConnectionString))
    .AddScoped<CompanyRepository>()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger()
    .UseSwaggerUI()
    .UseHttpsRedirection();
SetMappings(builder, app).Run();

static WebApplication SetMappings(WebApplicationBuilder builder, WebApplication application)
{
    application.MapGet("/department", async (CompanyRepository company) =>
            JsonSerializer.Serialize(await company.GetDepartmentAsync(), SerializerOptions))
        .RequireAuthorization();
    application.MapPut("createuser", async (UserModel user, CompanyRepository company) =>
        await company.CreateUserAsync(user) ? Results.Ok(user) : Results.BadRequest(user));
    application.MapGet("readuser", async (int id, CompanyRepository company) =>
    {
        var user = await company.ReadUserAsync(id);
        return user is not null ? Results.Ok(user) : Results.NotFound(id);
    });
    application.MapPatch("updateuser", async (UserModel user, CompanyRepository company) =>
        Results.Created($"https://localhost/readuser?id={user.Id}", await company.UpdateUserAsync(user)));
    application.MapDelete("deleteuser", async (int id, CompanyRepository company) =>
        Results.Ok(await company.DeleteUserAsync(id)));
    application.MapPost("/getToken", async (AuthModel auth, CompanyRepository company) =>
    {
        if (auth is null) return Results.Unauthorized();
        var manager = await company.GetManager(auth);
        if (manager is null) return Results.Unauthorized();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new("Id", $"{Guid.NewGuid()}"),
                new(JwtRegisteredClaimNames.Sub, manager.Login),
                new(JwtRegisteredClaimNames.Email, manager.Login),
                new(JwtRegisteredClaimNames.Jti, $"{Guid.NewGuid()}")
            }),
            Expires = DateTime.UtcNow.AddMinutes(5),
            Issuer = HostAddress,
            Audience = HostAddress,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(JwtKey),
                SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Results.Ok(tokenHandler.WriteToken(token));
    }).AllowAnonymous();


    return application;
}