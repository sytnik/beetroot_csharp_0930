using Lesson34.DAO;

namespace Lesson34.Service;

public interface ICompanyRepository
{
    Task<Department> GetDepartmentAsync();
    Task AddUserAsync(User user);
}