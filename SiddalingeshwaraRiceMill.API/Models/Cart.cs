﻿using System;
using System.Collections.Generic;

namespace SiddalingeshwaraRiceMill.API.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int? CustomerId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public DateTime? AddedDate { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ProductTbl? Product { get; set; }
}
