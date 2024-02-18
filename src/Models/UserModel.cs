using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Library.Models
{
    public class UserModel : IdentityUser
    {
        [Required]
       [DataType(DataType.Password)]
        [NotMapped]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [NotMapped]
        public string Repassword { get; set; }
        public UserModel() : base()
        {
            
        }
    }
}
