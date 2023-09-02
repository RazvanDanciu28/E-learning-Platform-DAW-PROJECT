using ELP.Models.AssociativeModels;
using ELP.Models.Base;
using System.ComponentModel.DataAnnotations;


namespace ELP.Models{

    public class Teacher : BaseEntity{
        [Required]
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string phoneNumber {get; set;}
        public int salary (get; set;)

        //the teacher's course
        public Guid? CourseId{get; set;}
        public Course? Course {get; set;}

        //the teacher's students
        public ICollection<User>? students {get; set;}
        //students who have thid teacher as their favourite
        public ICollection<User>? studentsFav {get; set;}
    }
}