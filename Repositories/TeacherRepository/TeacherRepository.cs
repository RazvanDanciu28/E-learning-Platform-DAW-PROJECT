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

        public async Task<IEnumerable<Teacher>> GetAllTeachers(){
            return await tContext.Teachers.ToListAsync();
        }
    }
}