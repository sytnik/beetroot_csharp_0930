using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson31EF;

public record User
{
    [Key] public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Info { get; set; }
    [NotMapped]
    public string FullName { get; set; }
    public DetailsInfo Details { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
}