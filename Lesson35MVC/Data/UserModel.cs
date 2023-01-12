using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson35MVC.Data;

public record UserModel
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Info { get; set; }
    public int? DepartmentId { get; set; }
}