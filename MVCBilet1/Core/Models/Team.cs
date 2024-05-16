using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Team:BaseEntity
    {
        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Fullname { get; set; } = null!;
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Position { get; set; } = null!;
        [Required]
        public string? ImgUrl { get; set; } = null!;
        [NotMapped]
        public IFormFile? PhotoFile { get; set; }
        
    }
}
