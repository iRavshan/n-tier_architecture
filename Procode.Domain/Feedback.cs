using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Domain
{
    public class Feedback
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string AuthorEmail { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }
    }
}
