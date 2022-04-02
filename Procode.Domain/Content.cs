using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Domain
{
    public class Content
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string AuthorFirstname { get; set; }

        [Required]
        public string AuthorLastname { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string Tag { get; set; }

        [Required]
        public string Text { get; set; }
       
        public string YouTubeVideoID { get; set; }

        public string GitUrl { get; set; }

        public DateTime CreateTime { get; set; }

    }
}
