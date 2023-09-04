using ELP.Data;
using ELP.Models;
using ELP.Repositories.ITeacherRepository;
using ELP.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace ELP.Repositories.TeacherRepository{

    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository{
        private readonly ELPContext tContext;

        public TeacherRepository(ELPContext context) : base(context){
            this.tContext = context;
        }

        public async Task<IEnumerable<Teacher>> GetTeacherWithStudentsByNameAsync(string teacherFirstName, string teacherLastName){
            return await tContext.Teachers
                .Where(t => t.FirstName == teacherFirstName && t.LastName == teacherLastName)
                .Include(t => t.students)
                .ToListAsync();
        }

        public async Task<IEnumerable<Teacher>> GetTeacherWithSalary(int givenSalary, int indicator){
            if (indicator == 1){
                return await tContext.Teachers
                    .Where(t => t.salary > givenSalary)
                    .Include(t => t.salary)
                    .ToListAsync();
            }
            else if (indicator == -1){
                return await tContext.Teachers
                    .Where(t => t.salary < givenSalary)
                    .Include(t => t.salary)
                    .ToListAsync();
            }
            else if (indicator == 0){
                return await tContext.Teachers
                    .Where(t => t.salary == givenSalary)
                    .Include(t => t.salary)
                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachers(){
            return await tContext.Teachers.ToListAsync();
        }
    }
}