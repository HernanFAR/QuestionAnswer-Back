using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Models
{
    public class EmailInformation
    {
        [Required]
        public List<string> Tos { get; set; }

        [Required]
        public List<string> Copies { get; set; }

        [Required]
        [MinLength(1)]
        public string Subject { get; set; }

        [Required]
        [MinLength(1)]
        public string Content { get; set; }

    }
}
