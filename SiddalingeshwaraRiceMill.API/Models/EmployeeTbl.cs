using System;
using System.Collections.Generic;

namespace SiddalingeshwaraRiceMill.API.Models;

public partial class EmployeeTbl
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public int? Role { get; set; }

    public int? DobDay { get; set; }

    public int? DobMonth { get; set; }

    public int? DobYear { get; set; }

    public int? DepartmentId { get; set; }

    public int? AddressId { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual AddressTbl? Address { get; set; }

    public virtual DepartmentTbl? Department { get; set; }

    public virtual ICollection<OrdersTbl> OrdersTbls { get; } = new List<OrdersTbl>();

    public virtual RoleTbl? RoleNavigation { get; set; }

    public virtual ICollection<SalaryTbl> SalaryTbls { get; } = new List<SalaryTbl>();
}
