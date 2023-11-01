using DapperProcedure.Models;
using DapperProcedure.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperProcedure.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class StudentsController : ControllerBase
    {
        StudentService service = new StudentService();

        [HttpGet]
        public IActionResult GetStudentById(int Id)
        {
            Student student = service.GetStudentById(Id);

            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentByYear(string BeginYear, string EndYear)
        {
            var students = await service.GetStudentByYear(BeginYear, EndYear);

            return Ok(students);
        }
    }
}
