namespace ELP.Models.DTOs.Teachers{

    public class TeacherResponseDTO{
        
        public Guid TeacherId{get; set;}
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public IEnumerable<User>? Students{get; set;}
    }
}