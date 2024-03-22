using System;
using System.Collections.Generic;

namespace SiddalingeshwaraRiceMill.API.Models;

public partial class OrdersTbl
{
    public int OrderId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public decimal? Cost { get; set; }

    public decimal? Tax { get; set; }

    public decimal? Total { get; set; }

    public int? ProductId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? OrderDay { get; set; }

    public int? OrderMonth { get; set; }

    public int? OrderYear { get; set; }

    public string? OrderStatus { get; set; }

    public int? ShippingId { get; set; }

    public int? EmployeeId { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<DeliveryTable> DeliveryTables { get; } = new List<DeliveryTable>();

    public virtual EmployeeTbl? Employee { get; set; }

    public virtual ProductTbl? Product { get; set; }

    public virtual ICollection<ShippingTable> ShippingTables { get; } = new List<ShippingTable>();
}
