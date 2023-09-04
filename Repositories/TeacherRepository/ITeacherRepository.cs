using ELP.Models;
using ELP.Repositories.GenericRepository;

namespace ELP.Repositories.ITeacherRepository{
    public interface ITeacherRepository : IGenericRepository<Teacher>{
        //get a teacher with all his students
        Task<IEnumerable<Teacher>> GetTeacherWithStudentsByNameAsync(string teacherFirstName, string teacherLastName);

        //get all teachers with higher, lower or equal than a given number
        //if indicator == 1 => get teachers with salary higher than given number
        //if indicator == -1 => get teahcers with salary lower than given number
        //if indicator == 0 => get teachers with salary equal to given bnumber
        Task<IEnumerable<Teacher>> GetTeacherWithSalary (int givenSalary, int indicator);

        //get all teachers
        public Task<IEnumerable<Teacher>> GetAllTeachers();
    }
}