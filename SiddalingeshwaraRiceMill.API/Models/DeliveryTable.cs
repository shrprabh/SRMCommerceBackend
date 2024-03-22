using System;
using System.Collections.Generic;

namespace SiddalingeshwaraRiceMill.API.Models;

public partial class DeliveryTable
{
    public int DeliveryId { get; set; }

    public int? CustomerId { get; set; }

    public int? OrderId { get; set; }

    public int? ShippingId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual OrdersTbl? Order { get; set; }

    public virtual ShippingTable? Shipping { get; set; }
}
