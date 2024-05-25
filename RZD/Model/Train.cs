using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RZD;

public partial class Train
{
    public int TrainId { get; set; }

    public int TrainNumber { get; set; }

    public int NumberOfWagons { get; set; }

    public DateTime StartOfInspection { get; set; }

    public DateTime EndOfInspection { get; set; }

    public bool TechnicalReadiness { get; set; }
    [NotMapped]
    public string IsTechnicalReadiness
    {
        get
        {
            return TechnicalReadiness? "Готов" : "Не готов";
        }
    }

    public string? Description { get; set; }

    public int WagonInspectorId { get; set; }

    public virtual User UserNavigation { get; set; } = null!;
}
