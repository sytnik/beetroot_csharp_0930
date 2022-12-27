using Lesson35MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Lesson34.DAO;
using Lesson34.Model;
using Microsoft.EntityFrameworkCore;

namespace Lesson35MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NewDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, NewDbContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Index() =>
            View(await _dbContext.Users.ToListAsync());

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}