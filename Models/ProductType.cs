using System;
using System.Collections.Generic;

namespace Demomay.Models;

public partial class ProductType
{
    public int Id { get; set; }

    public string? ProducttypeName { get; set; }

    public decimal? Koefficient { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
