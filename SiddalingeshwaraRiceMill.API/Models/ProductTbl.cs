using System;
using System.Collections.Generic;

namespace SiddalingeshwaraRiceMill.API.Models;

public partial class ProductTbl
{
    public int ProductId { get; set; }

    public string? ProductType { get; set; }

    public decimal? Price { get; set; }

    public string? ProductDescription { get; set; }

    public int? QuantityAvailable { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual ICollection<OrdersTbl> OrdersTbls { get; } = new List<OrdersTbl>();
}
