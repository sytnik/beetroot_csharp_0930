using Lesson35MVC;
using Lesson35MVC.Data;
using Lesson35MVC.Logic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
BasePath = builder.Environment.WebRootPath;
builder.Logging.SetMinimumLevel(LogLevel.Debug);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NewDbContext>(options =>
    options.UseSqlServer(Settings.ConnectionString));
builder.Services.AddScoped<UserRepository>();
// var service = new CustAppService();
// builder.Services.AddSingleton(service);
builder.Services.AddHostedService<CustAppService>();
builder.Services
    .AddAuthentication(options =>
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
builder.Services.AddSession();
var app = builder.Build();
// app.Lifetime.ApplicationStopping.Register(() =>
// {
// });

// 50x codes
// app.UseExceptionHandler("/Home/Error");
app.UseDeveloperExceptionPage();
// if (!app.Environment.IsDevelopment())
// {
//  
//     // app.UseDeveloperExceptionPage();
//
// }
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
// must be before UseRouting
app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/home/error";
        await next();
    }
});
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{param?}");

await app.RunAsync();

public partial class Program
{
}