global using static Lesson35MVC.Logic.Storage;
using System.Diagnostics;
using System.Security.Claims;
using Lesson35MVC.Data;
using Lesson35MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lesson35MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly NewDbContext _dbContext;

    public List<UserLogin> MockUsers = new()
    {
        new UserLogin {Id = 1, UserName = "user1", Password = "pass1"},
        new UserLogin {Id = 2, UserName = "user2", Password = "pass2"},
    };

    public HomeController(ILogger<HomeController> logger, NewDbContext context)
    {
        _logger = logger;
        _dbContext = context;
        var firstheader = IndexTableHeaders[0];
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> Index() =>
        View(await _dbContext.Users.ToListAsync());


    public ActionResult ShowUsersDi() => View();

    public ActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(UserLogin login)
    {
        var dbUser = MockUsers
            .FirstOrDefault(u => u.UserName == login.UserName &&
                                 u.Password == login.Password);
        if (dbUser is not null)
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(
                    new List<Claim>
                    {
                        new(ClaimsIdentity.DefaultNameClaimType, dbUser.UserName)
                    },
                    "applicationCookie",
                    ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType))
            );
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<ActionResult<User>> EditUser(int id) =>
        View(await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id));

    [HttpPost]
    public async Task<IActionResult> EditUser(User user)
    {
        _dbContext.Entry(await _dbContext.Users
                .FirstOrDefaultAsync(dbUser => dbUser.Id == user.Id))
            .CurrentValues.SetValues(user);
        await _dbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel
        {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
}