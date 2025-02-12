﻿using TODOWebAPI.Models.Entities;

namespace TODOWebAPI.DTO.User
{
    public class CreateUserDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
