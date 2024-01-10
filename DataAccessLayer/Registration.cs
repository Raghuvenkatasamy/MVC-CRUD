using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DataAccessLayer
{
    public class Registration
    {
        [Key]
        public long RegistrationId { get; set; }

        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]

        public string ConformPassword { get; set; }

    }
}
