using System;
using System.Collections.Generic;

namespace Lesson31Dbfirst;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Info { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual DetailsInfo? DetailsInfo { get; set; }
}
