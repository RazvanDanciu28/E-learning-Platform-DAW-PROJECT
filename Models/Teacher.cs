using ELP.Models.AssociativeModels;
using ELP.Models.Base;
using System.ComponentModel.DataAnnotations;


namespace ELP.Models{

    public class Teacher : BaseEntity{
        [Required]
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string phoneNumber {get; set;}

        //the teacher's course
        public Course? course {get; set;}

        //the teacher's students
        public ICollection<User>? students {get; set;}
    }
}