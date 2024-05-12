using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalksAPI.Controllers
{
    // https://localhost:port/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: https://localhost:port/api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] teste = new string[] { "teste1", "teste2", "teste3", "teste4", "teste5" };

            return Ok(teste);
        }
    }
}
