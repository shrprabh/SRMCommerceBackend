using System;
using System.Collections.Generic;

namespace SiddalingeshwaraRiceMill.API.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Name { get; set; }

    public string? Gmail { get; set; }

    public string? Password { get; set; }

    public DateTime? Dob { get; set; }

    public int? AddressId { get; set; }

    public string? Phone { get; set; }

    public virtual AddressTbl? Address { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual ICollection<DeliveryTable> DeliveryTables { get; } = new List<DeliveryTable>();

    public virtual ICollection<OrdersTbl> OrdersTbls { get; } = new List<OrdersTbl>();
}
