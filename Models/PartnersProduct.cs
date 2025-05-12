using System;
using System.Collections.Generic;

namespace Demomay.Models;

public partial class PartnersProduct
{
    public int Id { get; set; }

    public int? PoductArticlenumber { get; set; }

    public int? PartnerId { get; set; }

    public int? Kolvoproduction { get; set; }

    public DateTime? Saledate { get; set; }

    public virtual Partner? Partner { get; set; }

    public virtual Product? PoductArticlenumberNavigation { get; set; }
}
