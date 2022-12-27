namespace Lesson34.WebService;

public interface ICompanyRepository
{
    Task<Department> GetDepartmentAsync();
    Task<bool> CreateUserAsync(UserModel userModel);
    Task<User?> ReadUserAsync(int id);
    Task<bool> UpdateUserAsync(UserModel userModel);
    Task<bool> DeleteUserAsync(int id);
}