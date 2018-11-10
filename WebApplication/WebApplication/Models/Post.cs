using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Post
    {
        [Required]
        [Key]
        public int PostKey { get; set; }

        [MaxLength(127)]
        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        [MaxLength(300)]
        public string PostMessage { get; set; }
    }
}
