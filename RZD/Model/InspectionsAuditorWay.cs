using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RZD;

public partial class InspectionsAuditorWay
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int Nways { get; set; }

    public string Description { get; set; } = null!;

    public bool ClosureOfTheMovement { get; set; }
    [NotMapped]
    public string IsClosureOfTheMovement
    {
        get
        {
            return ClosureOfTheMovement? "Закрыто" : "Отправлено путейцам";
        }
    }

    public int Auditor { get; set; }

    public virtual User AuditorNavigation { get; set; } = null!;

    public virtual Way NwaysNavigation { get; set; } = null!;
}
