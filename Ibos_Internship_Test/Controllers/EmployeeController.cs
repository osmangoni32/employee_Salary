using Ibos_Internship_Test.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var x =  _appDbContext.TblEmployees.Select(a => a).OrderByDescending(a => a.EmployeeSalary).ToList();
            return Ok(x);
        }




    }
}
