using IMDB.Models.Base;
using IMDB.Models.Enums;
using System.ComponentModel.DataAnnotations;



namespace ELP.Models{

    public class Course: BaseEntity{
        public string CourseName {get; set;}
        public string? CourseDescription {get; set;}

        public Guid? TeacherId{get; set;}
        public Teacher? Teacher{get; set;}

        public ICollection<User>? CourseUsers{get; set;} 
    }
}