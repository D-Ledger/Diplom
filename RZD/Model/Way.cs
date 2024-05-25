using System;
using System.Collections.Generic;

namespace RZD;

public partial class Way
{
    public int Id { get; set; }

    public string WaysName { get; set; } = null!;

    public int ViewWays { get; set; }

    public virtual ICollection<InspectionsAuditorWay> InspectionsAuditorWays { get; set; } = new List<InspectionsAuditorWay>();

    public virtual ICollection<RailwayEngineerInspection> RailwayEngineerInspections { get; set; } = new List<RailwayEngineerInspection>();

    public virtual TypesPath ViewWaysNavigation { get; set; } = null!;
}
