using Ibos_Internship_Test.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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



    }
}
