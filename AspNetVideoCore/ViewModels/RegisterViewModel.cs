﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AspNetVideoCore.ViewModels
{
    //view model for the Register view.
    public class RegisterViewModel  
    {
        [Required, MaxLength(255)]
        public string Username { get; set;}

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
