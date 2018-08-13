using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace AspNetVideoCore.ViewModels
{
    //This model is responsible for passing the login information
    //provided by the user, and the ReturnUrl URL parameter value, to the HTTP POST Login action.

    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [DataType(DataType.Password), Required]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
