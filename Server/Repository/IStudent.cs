using SchooleManagment.Shared.Model;

namespace SchooleManagment.Server.Repository
{
    public interface IStudent
    {
        public Task<List<student>> GetAll();
        public Task<student> GetStudentDetails(int id);

        public Task<student> AddStudent(student student);

        public Task<bool> UpdateStudent(int id, student student);
        public Task<bool> DeleteStudent(int id);
    }
}
