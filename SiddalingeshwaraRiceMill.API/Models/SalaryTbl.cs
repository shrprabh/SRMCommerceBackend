using System;
using System.Collections.Generic;

namespace SiddalingeshwaraRiceMill.API.Models;

public partial class SalaryTbl
{
    public int SalaryId { get; set; }

    public decimal? Salary { get; set; }

    public decimal? Bonus { get; set; }

    public DateTime? SalaryDate { get; set; }

    public int? EmployeeId { get; set; }

    public virtual EmployeeTbl? Employee { get; set; }
}
