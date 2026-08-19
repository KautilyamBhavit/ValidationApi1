using Microsoft.AspNetCore.Mvc;
using ValidationApi.Models;

namespace ValidationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(student);
        }

        [HttpGet("error")]
        public IActionResult TestError()
        {
            throw new Exception("This is a test exception");
        }
    }
}