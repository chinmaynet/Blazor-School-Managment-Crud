using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchooleManagment.Server.Data;
using SchooleManagment.Shared.Model;
using System.Diagnostics.Eventing.Reader;

namespace SchooleManagment.Server.Repository
{
    public class StudentRepository : IStudent
    {
        private SchoolDbContext _context;
        public StudentRepository(SchoolDbContext  conext)
        {
            _context = conext;
        }

        [HttpPost("AddStudent")]
        public async Task<student> AddStudent(student studentt)
        {
            var student = await _context.Students.AddAsync(studentt);
            _context.SaveChanges();

            return student.Entity;
        }

        [HttpDelete("DeleteStudent/{id}")]
        public async Task<bool> DeleteStudent(int id)
        {
            var getStudent = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (getStudent != null)
            {
                _context.Students.Remove(getStudent);
                _context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpGet]
        public async Task<List<student>> GetAll()
        {
            return await _context.Students.ToListAsync();   
        }


        [HttpGet("GetStudentDetails")]
        public Task<student> GetStudentDetails(int id)
        {
            var getStudent = _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            return getStudent;
        }

   
        public async Task<bool> UpdateStudent(int id, student student)
        {
            var getStudent =await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (getStudent != null)
            {
                getStudent.FirstName = student.FirstName;
                getStudent.LastName = student.LastName;
                getStudent.StudentRollNo = student.StudentRollNo;
                getStudent.StudentStd = student.StudentStd;


                _context.Update(getStudent);
                _context.SaveChanges();


                return true;
            }
            else {
                return false;
            
            
            }

           

        }
    }
}
