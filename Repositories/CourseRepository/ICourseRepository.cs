using ELP.Models;
using ELP.Repositories.GenericRepository;

namespace ElP.Repositories.ICourseRepository{
    public interface ICourseRepository : IGenericRepository<Course>{

        //get all courses by studend's name
        Task<IEnumerable<Course>> GetCoursesByStudentNameAsync(string studentFirstName, string studentLastName);

        //get all courses cheaper, more expensive or as the same price as a given number
        //if indicator == 1 => get courses more expensive
        //if indicator == -1 => get course cheaper
        //if indicator == 0 => get courses wiht price equal to number
        Task<IEnumerable<Course>> GetCoursesWithPrice(int givenPrice, int indicator);

        //get all courses
        Task<IEnumerable<Course>> GetAllCourses();
    }
}