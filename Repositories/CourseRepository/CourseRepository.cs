using System.Linq;
using System.Threading.Tasks;
using ELP.Data;
using ELP.Models;
using ELP.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;


namespace ELP.Repositories.CourseRepository{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository{
        private readonly ELPContext cContext;

        public CourseRepository(ELPContext cContext) : base(cContext){
            this.cContext = cContext;
        }


        public async Task<IEnumerable<Course>> GetCoursesByStudentNameAsync(string studentFirstName, string studentLastName){
            return await cContext.Users
                .Where(u => u.firstName == studentFirstName && u.lastName == studentLastName)
                .Include(u => u.Courses)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesWithPrice(int givenPrice, int indicator){
            if (indicator == 1){
                return await cContext.Courses
                    .Where(c => c.pricePerLesson > givenPrice)
                    .Include(c => c.pricePerLesson)
                    .ToListAsync();
            }
            else if (indicator == -1){
                return await cContext.Courses
                    .Where(c => c.pricePerLesson < givenPrice)
                    .Include(c => c.pricePerLesson)
                    .ToListAsync();
            }
            else if (indicator == 0){
                return await cContext.Courses
                    .Where(c => c.pricePerLesson == givenPrice)
                    .Include(c => c.pricePerLesson)
                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<Course>> GetAllCourses(){
            return await cContext.Courses.ToList();
        }
    }
}