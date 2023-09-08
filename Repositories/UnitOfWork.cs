using ELP.Data;
using ELP.Repositories.TeacherRepository;
using ELP.Repositories.ITeacherRepository;
using ELP.Repositories.CourseRepository;
using ELP.Repositories.ICourseRepository;
using ELP.Repositories.UserRepository;
using ELP.Repositories.IUserRepository;
using Microsoft.Data.SqlClient;


namespace ELP.Repositories{
    public interface IUnitOfWork{
        Task<bool> SaveAsync();
        ITeacherRepository TeacherRepository{get; set;}
        ICourseRepository CourseRepository{get; set;}
        IUserRepository UserRepository{get; set;}
    }

    public class UnitOfWork : IUnitOfWork{
        public ITeacherRepository TeacherRepository {get; set;}
        public ICourseRepository CourseRepository{get; set;}
        public IUserRepository UserRepository{get; set;}

        private ELPContext context {get; set;}

        public UnitOfWork(ITeacherRepository trep, ICourseRepository crep, IUserRepository urep, ELPContext _context){
            TeacherRepository = trep;
            CourseRepository = crep;
            UserRepository = urep;
            context = _context;
        }

        public async Task<bool> SaveAsync() {
            try{
                return await context.SaveChangesAsync() > 0;
            }
            catch(SqlException ex){
                Console.WriteLine("Oops! Something went wrong!");
                Console.WriteLine(ex.Message);
            }
            
            return false;
        }
    }
}