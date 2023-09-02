using ELP.Models;
using ELP.Models.AsssociativeModels;
using Microsoft.EntityFrameworkCore;

namespace ELP.Data{

    public class ELPContext: DbContext{
        public DbSet<User> Users {get; set;}
        public DbSet<Course> Courses {get; set;}
        public DbSet<Teacher> Teachers {get; set;}

        public ELPContext(DbContextOptions<ELPContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //primary keys
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Teacher>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Course>()
                .HasKey(c => c.id);


            //one to one(A teacher can teach only one course and a course can be teached by only one teacher)
            modelBuilder.Entity<TeacherCourse>()
                .HasKey(k => k.TeacherId, k.CourseId);


            //one to many (A student can have only one favourite teacher but a teacher can be favorized by multiple students)
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.studentsFav)
                .WithOne(u => u.FavouriteTeacher)
                .HasForeignKey(u => u.TeacherId);


            //many to many
            //a student can learn multiple courses and a course can be learned by multiple students
            modelBuilder.Entity<UserCourse>()
                .HasKey(k => k.UserId, k.CourseId); 
            
            //a student can learn from multiple teachers and a teacher can teach to multiple students
            modelBuilder.Entity<UserTeacher>()
                .HasKey(k => k.UserId, k.CourseId);


            base.OnModelCreating(modelBuilder);


            
            
    
        }
    }
}