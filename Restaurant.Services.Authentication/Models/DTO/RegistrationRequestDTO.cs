﻿namespace Restaurant.Services.Authentication.Models.DTO
{
    public class RegistrationRequestDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
