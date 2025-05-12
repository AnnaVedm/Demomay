using System;
using System.Collections.Generic;

namespace Demomay.Models;

public partial class Partner
{
    public int Id { get; set; }

    public int? Partnertypeid { get; set; }

    public string? Partnername { get; set; }

    public string? Director { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? Inn { get; set; }

    public int? Rating { get; set; }

    public virtual ICollection<PartnersProduct> PartnersProducts { get; } = new List<PartnersProduct>();

    public virtual PartnerType? Partnertype { get; set; }
}
