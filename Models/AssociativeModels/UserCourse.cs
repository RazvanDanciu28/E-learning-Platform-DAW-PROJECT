namespace ELP.Models.AssociativeModels{
    
    public class UserCourse{
        public Guid UserId {get; set;}
        public User? User {get; set;}

        public Guid CourseId {get; set;}
        public Course? Course {get; set;}
    }
}