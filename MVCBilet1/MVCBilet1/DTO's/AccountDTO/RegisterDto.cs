﻿using System.ComponentModel.DataAnnotations;

namespace MVCBilet1.DTO_s.AccountDTO
{
    public class RegisterDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Surname { get; set; } = null!;
        [Required]
        [MinLength(7)]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [DataType(DataType.Password),Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
