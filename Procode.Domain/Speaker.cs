using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Domain
{
    public class Speaker
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Job { get; set; }

        [Required]
        public string PhotoUrl { get; set; }

        [Required]
        public string Quote { get; set; }
    }
}
