using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ibos_Internship_Test.Models;

[Table("tblEmployee")]
public partial class TblEmployee
{
    [Key]
    [Column("employeeId")]
    public int EmployeeId { get; set; }

    [Column("employeeName")]
    [StringLength(100)]
    [Unicode(false)]
    public string? EmployeeName { get; set; }

    [Column("employeeCode")]
    [StringLength(10)]
    [Unicode(false)]
    public string? EmployeeCode { get; set; }

    [Column("employeeSalary", TypeName = "decimal(10, 2)")]
    public decimal? EmployeeSalary { get; set; }
}
