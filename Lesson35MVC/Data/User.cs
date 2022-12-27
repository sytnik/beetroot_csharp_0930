using System.ComponentModel.DataAnnotations.Schema;
using Lesson34.Model;

namespace Lesson34.DAO;

public record User : UserModel
{
    public DetailsInfo Details { get; set; }
    public Department Department { get; set; }
    [NotMapped] public string FullName => $"{FirstName} {LastName}";

    public User()
    {
    }

    public User(UserModel model)
    {
        Id = model.Id;
        FirstName = model.FirstName;
        LastName = model.LastName;
        Info = model.Info;
        DepartmentId = model.DepartmentId;
    }
}