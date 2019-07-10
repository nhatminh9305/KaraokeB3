using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace B3.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "UserName cannot be longer than 30 characters.")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(200, ErrorMessage = "Password cannot be longer than 30 characters.")]
        public string Password { get; set; }
        public String Avata { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
