using Ibos_Internship_Test.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Ibos_Internship_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        [Route("EmployeeSalary")]

        public IActionResult EmployeeSalary()
        {
            var employee_list_des =  _appDbContext.TblEmployees.Select(a => a).OrderByDescending(a => a.EmployeeSalary).ToList();
            return Ok(employee_list_des);
        }


        [HttpGet]
        [Route("Employeeattendance")]

        public IActionResult Employeeattendance()
        {
            var absent = _appDbContext.TblEmployeeAttendances
        .Where(a => a.IsAbsent == true)
        .Select(a => a.EmployeeId)
        .Distinct()
        .ToList(); 
            return Ok(absent);
        }

        [HttpPut]
        [Route("EmployeeSalary")]
        public IActionResult EmployeeCodeUpdate(string employeeCode, long employeeId)
        {
            var duplicate_check_with_all_Except_own = _appDbContext.TblEmployees.Select(a => a).Where(a => a.EmployeeId != employeeId && a.EmployeeCode == employeeCode);

            if (duplicate_check_with_all_Except_own.Count() > 0)
            {
                return BadRequest("Duplicate detected");
            }
            else
            {
                var Update_employeeCode = _appDbContext.TblEmployees.Where(z => z.EmployeeId == employeeId).FirstOrDefault();
                Update_employeeCode.EmployeeCode = employeeCode;
                _appDbContext.TblEmployees.Update(Update_employeeCode);
                _appDbContext.SaveChangesAsync();
                return Ok("Successfully done ");
            }
        }



    }
}
