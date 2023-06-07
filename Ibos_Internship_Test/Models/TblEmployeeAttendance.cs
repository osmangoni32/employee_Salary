using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ibos_Internship_Test.Models;

[Keyless]
[Table("tblEmployeeAttendance")]
public partial class TblEmployeeAttendance
{
    [Column("employeeId")]
    public int? EmployeeId { get; set; }

    [Column("attendanceDate", TypeName = "date")]
    public DateTime? AttendanceDate { get; set; }

    [Column("isPresent")]
    public bool? IsPresent { get; set; }

    [Column("isAbsent")]
    public bool? IsAbsent { get; set; }

    [Column("isOffday")]
    public bool? IsOffday { get; set; }

    [ForeignKey("EmployeeId")]
    public virtual TblEmployee? Employee { get; set; }
}
