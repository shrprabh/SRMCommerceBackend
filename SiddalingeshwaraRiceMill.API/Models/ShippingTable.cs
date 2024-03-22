using System;
using System.Collections.Generic;

namespace SiddalingeshwaraRiceMill.API.Models;

public partial class ShippingTable
{
    public int ShippingId { get; set; }

    public DateTime? ShippingDate { get; set; }

    public DateTime? EstimatedDeliveryDate { get; set; }

    public DateTime? ActualDeliveryDate { get; set; }

    public int? OrderId { get; set; }

    public string? ShippingStatus { get; set; }

    public virtual ICollection<DeliveryTable> DeliveryTables { get; } = new List<DeliveryTable>();

    public virtual OrdersTbl? Order { get; set; }
}
