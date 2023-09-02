namespace ELP.Models.DTOs.Users{

    public class UserResponseDTO{

        public Guid UserId {get; set;}
        public ICollection<Course>? Courses;
        public string? email {get; set;}
        public int? budget {get; set;}
        public string? firstName {get; set;}
        public string? lastName {get; set;}

    }
}