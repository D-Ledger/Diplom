using System;
using System.Collections.Generic;

namespace RZD;

public partial class User
{
    public int Id { get; set; }

    public string Fullname { get; set; } = null!;

    public string Username { get; set; } = null!;

    public int PositionId { get; set; }

    public DateTime? Birthdate { get; set; }

    public int Gender { get; set; }

    public string Password { get; set; } = null!;

    public virtual Floor GenderNavigation { get; set; } = null!;

    public virtual ICollection<InspectionsAuditorTrain> InspectionsAuditorTrains { get; set; } = new List<InspectionsAuditorTrain>();

    public virtual ICollection<InspectionsAuditorWay> InspectionsAuditorWays { get; set; } = new List<InspectionsAuditorWay>();

    public virtual Position PositionNavigation { get; set; } = null!;

    public virtual ICollection<RailwayEngineerInspection> RailwayEngineerInspections { get; set; } = new List<RailwayEngineerInspection>();

    public virtual ICollection<Train> Trains { get; set; } = new List<Train>();
}
