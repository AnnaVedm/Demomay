using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demomay.Models;

public partial class Product
{
    public int? Productiontypeid { get; set; }

    public string? Productname { get; set; }

    public int Article { get; set; }

    [NotMapped]
    public int? ProductSale {  get; set; }

    [NotMapped]
    public string ProductColor { get; set; } = string.Empty;

    public decimal? Maxcostforpartner { get; set; }

    public virtual ICollection<PartnersProduct> PartnersProducts { get; } = new List<PartnersProduct>();

    public virtual ProductType? Productiontype { get; set; }
}
