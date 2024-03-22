using System;
using System.Collections.Generic;

namespace SiddalingeshwaraRiceMill.API.Models;

public partial class RoleTbl
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public int DeptId { get; set; }

    public virtual DepartmentTbl? Dept { get; set; }

    public virtual ICollection<EmployeeTbl> EmployeeTbls { get; } = new List<EmployeeTbl>();
}
