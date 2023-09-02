namespace ELP.Models.DTOs.Courses{

    public class CourseResponseDTO{
        
        public Guid CourseId {get; set;}

        public string CourseName {get; set;}
        public string? CourseDescription {get; set;}

        public Teacher? Teacher {get; set;}
    }
}