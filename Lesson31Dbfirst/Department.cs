using System;
using System.Collections.Generic;

namespace Lesson31Dbfirst;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Data { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
