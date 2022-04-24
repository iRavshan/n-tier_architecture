using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Domain
{
    public class Post
    {
        [Key]
        [Column("PostId")]
   
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Text { get; set; }

        public string Tags { get; set; }

        public string AuthorUsername { get; set; }

        public User User { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
