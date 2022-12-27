namespace Lesson34.WebService;

public class CompanyRepository : ICompanyRepository
{
    private readonly NewDbContext _context;
    public CompanyRepository(NewDbContext context) => _context = context;

    public async Task<Department> GetDepartmentAsync() =>
        await _context.Set<Department>()
            .Include(department => department.Users)
            .ThenInclude(user => user.Details)
            .FirstAsync();

    public async Task<bool> CreateUserAsync(UserModel userModel)
    {
        var newUser = await _context.Set<User>()
            .AllAsync(user => user.Id != userModel.Id)
            ? new User(userModel)
            : null;
        return await ValidateAndProcess(newUser,
            () => _context.Set<User>().AddAsync(newUser!));
        // await _context.Set<User>().AddAsync(newUser);
        // await _context.SaveChangesAsync();
    }

    public async Task<User?> ReadUserAsync(int id) =>
        await _context.Set<User>().FirstOrDefaultAsync(user => user.Id == id);

    public async Task<bool> UpdateUserAsync(UserModel userModel)
    {
        var existingUser = await _context.Set<User>()
            .FirstOrDefaultAsync(user => user.Id == userModel.Id);
        return await ValidateAndProcess(existingUser,
            () => _context.Entry(existingUser!).CurrentValues.SetValues(new User(userModel)));
        // if (existingUser is null) return;
        // _context.Entry(existingUser).CurrentValues.SetValues(new User(userModel));
        // await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var existingUser = await _context.Set<User>()
            .FirstOrDefaultAsync(user => user.Id == id);
        return await ValidateAndProcess(existingUser, 
            () => _context.Users.Remove(existingUser!));
        // if (existingUser is null) return;
        // _context.Users.Remove(existingUser);
        // await _context.SaveChangesAsync();
    }

    public async Task<bool> ValidateAndProcess(User? user, Delegate method)
    {
        if (user is null) return false;
        method.DynamicInvoke();
        await _context.SaveChangesAsync();
        return true;
    }
}