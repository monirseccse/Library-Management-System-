using Infrastructure.BusinessObjects;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibrarayManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;


        public StudentController(IStudentService studentService)
        {
           _studentService = studentService;
        }

        [HttpPost()]
        public async Task<IActionResult> Post(Student model)
        {
            try
            {
                await _studentService.AddStudent(model);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put(StudentEdit model)
        {
            try
            {
                await _studentService.UpdateStudent(model);

                return Ok();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
