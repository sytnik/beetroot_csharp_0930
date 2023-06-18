global using static Lesson35MVC.Logic.Storage;
using Lesson35MVC.Data;
using Lesson35MVC.Logic;
using Lesson35MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime;
using System.Security.Claims;
using System.Text.Json.Serialization;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;

namespace Lesson35MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly NewDbContext _dbContext;
    private readonly UserRepository _repository;
    private readonly IHostApplicationLifetime _host;

    public List<UserLogin> MockUsers = new()
    {
        new UserLogin { Id = 1, UserName = "user1", Password = "pass1", Role = "Admin" },
        new UserLogin { Id = 2, UserName = "user2", Password = "pass2", Role = "Support" },
        new UserLogin { Id = 3, UserName = "user3", Password = "pass3", Role = "Otherrole" }
    };

    public HomeController(ILogger<HomeController> logger, NewDbContext context,
        UserRepository repository, IHostApplicationLifetime host)
    {
        _logger = logger;
        _dbContext = context;
        _repository = repository;
        _host = host;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> Index()
    {
        var someusers = _dbContext.Set<User>().Take(5).ToList();
        HttpContext.Session.SetString("someusers", JsonConvert.SerializeObject(someusers));
        // await _dbContext.Database.ExecuteSqlAsync($"delete from users where id=1");
        // var k = _keys.GetAllKeys();
        // _keys.RevokeAllKeys(DateTimeOffset.Now, reason: "Revocation reason here.");
        var isserverGC = GCSettings.IsServerGC;
        //users -> where clause -> select some -> asenumerable() -> custom ordeering
        var users1 = _dbContext.Set<User>().SortByProp("LastName")
            .Where(user => user.FullName.Contains("us"));
        var users2 = _dbContext.Set<User>().Where(user => user.FullName.Contains("us"));

        // department.Foundation = DateOnly.FromDateTime(DateTime.Now);
        // _dbContext.Entry(_dbContext.Department.First()).CurrentValues.SetValues(department);
        // _dbContext.SaveChanges();
        var users = await _repository.GetUsers();
        // HttpContext.Session.SetString("data", "somevalue");
        ViewBag.SomeData1 = "hello world!";
        return View(users);
    }

    [HttpGet]
    public ActionResult<List<User>> IndexWithId(int id)
    {
        TempData["UserId"] = id;
        return RedirectToAction("Index");
    }


    public ActionResult ShowUsersDi()
    {
        // var data = HttpContext.Session.GetString("data");
        if (User.IsInRole("Admin")) return RedirectToAction("Index");
        return View();
        // return RedirectToAction("IndexWithId", "Home", new { id = 3 });
    }

    [AllowAnonymous]
    public ActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(UserLogin login)
    {
        var dbUser = MockUsers
            .FirstOrDefault(userLogin => userLogin.UserName == login.UserName &&
                                         userLogin.Password == login.Password);
        if (dbUser is not null)
        {
            _logger.LogInformation($"User {dbUser.UserName} has signed in");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(
                    new List<Claim>
                    {
                        new(ClaimsIdentity.DefaultNameClaimType, dbUser.UserName),
                        new(ClaimsIdentity.DefaultRoleClaimType, dbUser.Role)
                    },
                    "applicationCookie",
                    ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType))
            );
        }
        else _logger.LogError($"Invalid login {login.UserName} & {login.Password}");

        return RedirectToAction("Index");
    }

    public async Task<ActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index");
    }


    [HttpGet]
    public async Task<ActionResult<User>> EditUser(int id)
    {
        // HttpContext.Session.Remove("someusers");
        // var users = HttpContext.Session.GetString("someusers") ?? "";
        // var someusers = JsonConvert.DeserializeObject<List<User>>(users);

        if (!User.Identity!.IsAuthenticated || !User.IsInRole("Admin")) return RedirectToAction("Login");
        return View(await _dbContext.Set<User>().FirstOrDefaultAsync(user => user.Id == id));
    }

    public async Task<ActionResult<User>> ViewUser(int id) =>
        View(await _dbContext.Set<User>().FirstAsync(user => user.Id == id));

    [HttpPost, Authorize(Roles = "Admin")]
    public async Task<IActionResult> EditUser(User user)
    {
        // limit users table to 70 records on add
        var limit = 70;
        await _dbContext.BulkInsertOrUpdateAsync(new List<User> { user });
        await CheckUserTableLimit(limit);
        await UploadImage(user.Id, Request);
        return RedirectToAction("Index");
    }

    private async Task CheckUserTableLimit(int limit)
    {
        var amountToDelete = _dbContext.Set<User>().Count() - limit;
        if (amountToDelete > 0)
        {
            var usersToDelete = _dbContext.Set<User>()
                .OrderBy(u => u.Id).Take(amountToDelete).ToList();
            await _dbContext.BulkDeleteAsync(usersToDelete);
        }
    }

    public async Task<IActionResult> DeleteUser(int userId)
    {
        var user = await _dbContext.Set<User>()
            .FirstOrDefaultAsync(dbUser => dbUser.Id == userId);
        if (user != null)
        {
            _dbContext.Set<User>().Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }

    [Authorize]
    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel
        { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

    public IActionResult DeleteFile(string filePath)
    {
        var userId = filePath.Split("-").First();
        var fullpath = $"{BasePath}/users/{filePath}";
        if (System.IO.File.Exists(fullpath))
            System.IO.File.Delete(fullpath);
        return RedirectToAction("EditUser", new { id = userId });
    }

    public EmptyResult StopApp()
    {
        _host.StopApplication();
        return Empty;
    }
}