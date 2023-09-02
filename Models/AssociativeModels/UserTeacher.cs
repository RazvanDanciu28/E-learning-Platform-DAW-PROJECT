namespace ELP.Models.AssociativeModels{
    
    public class UserTeacher{
        public Guid UserId {get; set;}
        public User? User {get; set;}

        public Guid TeacherId {get; set;}
        public Teacher? Teacher {get; set;}
    }
}