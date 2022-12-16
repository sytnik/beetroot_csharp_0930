using Lesson30;
using Microsoft.EntityFrameworkCore;

//await DeleteSomeUsers(90, 100);
//await DeleteUser(202);
await GetData();
await CreateUser();
await UpdateUser(202);
await ReadData();


static async Task GetData()
{
    await using var context = new NewDbContext();
    var first = await context.Users
        .Include(user => user.Details)
        .FirstOrDefaultAsync(user => user.Id == 1);
    // select users within department
    var users1 = await context.Users
        .Include(user => user.Department)
        .Where(user => user.Department != null)
        .ToListAsync();
    // select department with all users
    var department1 = await context.Department
        .Include(department => department.Users)
        .FirstOrDefaultAsync();
    // select books/authors
    var books = await context.Book
        .Include(book => book.Authors)
        .ToListAsync();
    var authors = await context.Author
        .Include(author => author.Books)
        .ToListAsync();
    foreach (var book in books)
    {
        Console.WriteLine($"The book {book.Id} - {book.BookName}, authors:");
        foreach (var author in book.Authors)
        {
            Console.WriteLine($"{author.Id} - {author.FullName}");
        }
    }

    var user = context.Set<User>()
        .Include(user1 => user1.Department)
        .Include(user1 => user1.Details)
        .First(user1 => user1.Id == 1);
 

    var department2 = context.Set<Department>()
        .Include(department => department.Users)
        .ThenInclude(user1 => user1.Details)
        .First();
    Console.WriteLine();
}


static async Task CreateUser()
{
    await using var context = new NewDbContext();
    if (context.Users.Any(user => user.Id == 202)) return;
    var user = new User
    {
        Id = 202, FirstName = "user",
        LastName = "lastname", Info = "this is a new one"
    };
    await context.Users.AddAsync(user);
    await context.SaveChangesAsync();
}

static async Task DeleteUser(int id)
{
    await using var context = new NewDbContext();
    var first = await context.Users.FirstOrDefaultAsync(user => user.Id == id);
    if (first == null) return;
    context.Users.Remove(first);
    await context.SaveChangesAsync();
}

static async Task DeleteSomeUsers(int fromId, int toId)
{
    await using var context = new NewDbContext();
    var entities = await context.Users
        .Where(user => user.Id > fromId && user.Id < toId)
        .ToListAsync();
    if (!entities.Any()) return;
    context.Users.RemoveRange(entities);
    await context.SaveChangesAsync();
}

static async Task UpdateUser(int id)
{
    await using var context = new NewDbContext();
    var user = await context.Users.FirstOrDefaultAsync(user => user.Id == 202);
    var updatedUser = user with {FirstName = "UpdatedName", Info = "This was recently updated"};
    context.Entry(user).CurrentValues.SetValues(updatedUser);
    await context.SaveChangesAsync();
}


static async Task ReadData()
{
    await using var context = new NewDbContext();
    var first = await context.Users.FirstOrDefaultAsync(user => user.Id == 202);
    var users = await context.Users
        .Where(user => user.Id > 90 && user.Id < 100)
        .ToListAsync();
    Console.WriteLine();
}


await ReadData();

Console.WriteLine();