using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RZD;

public partial class InspectionsAuditorTrain
{
    public int Id { get; set; }

    public int TrainId { get; set; }

    public string DepartureStation { get; set; } = null!;

    public string ArrivalStation { get; set; } = null!;

    public DateTime Date { get; set; }

    public bool Readiness { get; set; }
    [NotMapped]
    public string IsReadiness
    {
        get
        {
            return Readiness ? "Оформлена" : "Отменена";
        }
    }

    public int Auditor { get; set; }

    public virtual User AuditorNavigation { get; set; } = null!;
}
