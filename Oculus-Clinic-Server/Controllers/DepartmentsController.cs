using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oculus_Clinic_Server.Data;
using Oculus_Clinic_Server.Data.Models;

namespace Oculus_Clinic_Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : Controller
    {
        private ApplicationDbContext _context;
        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("getdepartments")]
        public IActionResult GetDepartments()
        {
            var result = _context.Departments.AsNoTracking().ToList();
            return new ObjectResult(result);
        }

        [HttpPost("createdepartment")]
        public IActionResult CreateDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return new ObjectResult(department);
        }

        [HttpPut("updatedepartment")]
        public IActionResult UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
            return new ObjectResult(department);
        }


        [HttpDelete("delete/{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var department = _context.Departments.FirstOrDefault(x => x.Id == id);

            if (department == null)
            {
                return Ok();
            }

            _context.Departments.Remove(department);
            _context.SaveChanges();
            return Ok();
        }
    }
}
