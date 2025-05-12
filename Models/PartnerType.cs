using System;
using System.Collections.Generic;

namespace Demomay.Models;

public partial class PartnerType
{
    public int Id { get; set; }

    public string? PartnertypeName { get; set; }

    public virtual ICollection<Partner> Partners { get; } = new List<Partner>();
}
