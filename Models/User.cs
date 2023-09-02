using IMDB.Models.Base;
using IMDB.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ELP.Models{
    
    public class User: BaseEntity{
        [JsonIgnore]
        public ICollection<Course> Courses;
        public int budget;

        [MinLenght(6), MaxLength(128)]
        public string username{get; set;}

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid email format!")]
        public string email {get; set;}

        [RegularExpression(@"^(?=.{1,50}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$", ErrorMessage = "Invalid first name format!")]
        public string firstName {get; set;}

        [RegularExpression(@"^(?=.{1,50}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$", ErrorMessage = "Invalid last name format!")]
        public string lastName {get; set;}

        [Range(14, int.MaxValue, ErrorMessage = "You must be at least 14 years old!")]
        public int age { get; set; }

        [JsonIgnore]
        public string password {get; set;}
    }
}