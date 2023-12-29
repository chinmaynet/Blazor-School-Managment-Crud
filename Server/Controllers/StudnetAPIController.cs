using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchooleManagment.Server.Repository;
using SchooleManagment.Shared.Model;

namespace SchooleManagment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudnetAPIController : ControllerBase
    {
        public IStudent _student;
        public StudnetAPIController(IStudent student)
        {
            _student = student;
        }


        [HttpGet("GetAllStudents")]
        public async Task<List<student>> GetAllStudents()
        {
            return await _student.GetAll();
        }


        //[HttpGet("GetAllStudent")]
        //public async Task<IActionResult> GetAllStudent()
        //{
        //    try
        //    {
        //        var students = await _student.GetAll();
        //        return Ok(students);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception
        //        Console.WriteLine($"Exception in GetAllStudent: {ex.Message}");
        //        return StatusCode(500, "Internal Server Error");
        //    }
        //}



        [HttpGet("GetStudentDetails/{id}")]
        public async Task<student> GetStudentDetails(int id)
        {
            return await _student.GetStudentDetails(id);
        }


        [HttpPost("AddStudent")]
        public async Task<student> AddStudent(student studentt)
        {

            return await _student.AddStudent(studentt);
        }

        [HttpPatch("UpdateStudent/{id}")]
        public async Task<bool> UpdateStudent(int id, student student)
        {
            return await _student.UpdateStudent(id, student);
        }


        [HttpDelete("DeleteStudent/{id}")]
        public async Task<bool> DeleteStudent(int id)
        {
            return await _student.DeleteStudent(id);
        }
    }
}
