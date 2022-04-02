using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Domain
{
    public class User : IdentityUser
    { 

        [Required]
        public string Password { get; set; }

        public DateTime RegisteredDateTime { get; set; }

        public string Bio { get; set; }

        public string Company { get; set; }

        public string WebsiteUri { get; set; }

        public string Status { get; set; }

        public string Location { get; set; }

        public bool DisplayEmail { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
