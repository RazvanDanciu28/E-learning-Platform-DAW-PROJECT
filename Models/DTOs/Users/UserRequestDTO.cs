using System.ComponentModel.DataAnnotations;

namespace ELP.Models.DTOs.Users{

    public class UserRequestDTO{

        [Required, MaxLength(100)]
        public string username {get; set;}
        [Required]
        public string email {get; set;}

        [Required, MaxLength(64)]
        public string password{get; set;}
    }
}