using System;
using System.Collections.Generic;

namespace RZD;

public partial class TypesPath
{
    public int Id { get; set; }

    public string ViewWays { get; set; } = null!;

    public virtual ICollection<Way> Ways { get; set; } = new List<Way>();
}
