﻿using System.ComponentModel.DataAnnotations;

namespace ServiceStationAPI.Models
{
    public class Login
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User password is required")]
        public string Password { get; set; } 
    }
}
