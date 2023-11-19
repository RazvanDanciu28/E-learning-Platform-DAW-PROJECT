using ELP.Data;
using ELP.Models;
using ELP.Repositories.GenericRepository;
using ELP.Microsoft.EntityFrameworkCore;


namespace ELP.Repositories.UserRepository{

    public class UserRepository : GenericRepository<User>, IUserRepository{
        private readonly ELPContext uContext;
        public UserRepository(ELPContext context) : base(context){
            uContext = context;
        }

        
        
        ///ish
        public async Task<IEnumerable<User>> GetUserWithSameFavouriteTeacherAsync(string teacherFirstName, string teacherLastName){
            var usersWithSameFavTeacher = await (from user in uContext.Users
                        join FavouriteTeacher in uContext.Teachers on user.FavouriteTeacher.Id equals FavouriteTeacher.Id
                        where FavouriteTeacher.FirstName == teacherFirstName && FavouriteTeacher.LastName == teacherLastName
                        select user).ToListAsync();
            return usersWithSameFavTeacher;
        }

        public User FindByUsername(string username){
            return uContext.FirstOrDefault(x => x.Username == username);
        }

        // public  int GetNrCoursesByUsername(string username){
        //     return uContext.FirstOrDefault(x => x.Username == username).Courses.Count;
        // }
    }
}