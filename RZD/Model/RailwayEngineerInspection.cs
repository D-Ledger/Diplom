using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RZD;

public partial class RailwayEngineerInspection
{
    public int RailwayEngineerInspectionId { get; set; }

    public DateTime InspectionDate { get; set; }

    public int WaysNumber { get; set; }

    public int Vways { get; set; }

    public string Description { get; set; } = null!;

    public bool IsViolation { get; set; }
    [NotMapped]
    public string Violation
    {
        get
        {
            return IsViolation ? "Нарушение" : "Без нарушений";
        }
    }

    public int RailwayEngineerId { get; set; }

    public virtual User RailwayEngineer { get; set; } = null!;

    public virtual Way VwaysNavigation { get; set; } = null!;
}
