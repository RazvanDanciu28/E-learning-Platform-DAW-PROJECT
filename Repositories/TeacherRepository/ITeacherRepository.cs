using ELP.Models;
using ELP.Repositories.GenericRepository;

namespace ELP.Repositories.ITeacherRepository{
    public interface ITeacherRepository : IGenericRepository<Teacher>{
        //get a teacher with all his students
        Task<IEnumerable<Teacher>> GetTeacherWithStudentsByNameAsync(string teacherFirstName, string teacherLastName);

        //get all teachers
        public Task<IEnumerable<Teacher>> GetAllTeachers();
    }
}