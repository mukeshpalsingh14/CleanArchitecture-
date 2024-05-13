﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Dtos
{
    public class UserLoginDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }
      
        [Required]
        public string Password { get; set; }
       // public string Token { get; set; }
    }
}
