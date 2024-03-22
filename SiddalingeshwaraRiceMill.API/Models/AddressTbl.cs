using System;
using System.Collections.Generic;

namespace SiddalingeshwaraRiceMill.API.Models;

public partial class AddressTbl
{
    public int AddressId { get; set; }

    public int? EntityId { get; set; }

    public string? EntityType { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Pincode { get; set; }

    public string? Country { get; set; }

    public string? Language { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

    public virtual ICollection<EmployeeTbl> EmployeeTbls { get; } = new List<EmployeeTbl>();
}
