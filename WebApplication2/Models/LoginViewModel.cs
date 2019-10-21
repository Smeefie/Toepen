using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPToep.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Username is Required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]       
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginViewModel(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public LoginViewModel()
        {
           
        }
    }
}
