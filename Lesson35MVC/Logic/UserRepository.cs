using Lesson35MVC.Data;
using Microsoft.EntityFrameworkCore;

namespace Lesson35MVC.Logic;

public class UserRepository
{
    private readonly NewDbContext _context;
    public UserRepository(NewDbContext context) => _context = context;

    public Task<List<User>> GetUsers() => _context.Set<User>().ToListAsync();
}