using System;
using System.Collections.Generic;

namespace RZD;

public partial class Floor
{
    public int Id { get; set; }

    public string Gender { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
