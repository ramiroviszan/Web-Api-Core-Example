
using System.ComponentModel.DataAnnotations;

namespace WAC.WebAPI.Models {
    public class UserModelIn {

        [Required]
        public string Username {get; set;}
        
        [Required]
        public string Password {get; set;}

        [Required]
        public int Age {get; set;}
        
    }
}