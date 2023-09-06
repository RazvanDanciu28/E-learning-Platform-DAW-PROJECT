using ELP.Models;
using ELP.Repositories.GenericRepository;


namespace ELP.Repositories.IUserRepository{

    public interface IUserRepository : IGenericRepository<User>{
        //get users with the same favourite teacher given
        Task<IEnumerable<User>> GetUserWithSameFavouriteTeacherAsync(string teacherFirstName, string teacherLastName);

        User FindByUsername(string username);

        //get nr of courses for a student by its username
        int GetNrCoursesByUsername(string username);

    }
}