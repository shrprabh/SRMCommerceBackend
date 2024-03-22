using System;
using System.Collections.Generic;

namespace SiddalingeshwaraRiceMill.API.Models;

public partial class DepartmentTbl
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public string? DepartmentLocation { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public virtual ICollection<EmployeeTbl> EmployeeTbls { get; } = new List<EmployeeTbl>();

    public virtual ICollection<RoleTbl> RoleTbls { get; } = new List<RoleTbl>();
}
