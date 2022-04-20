using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Domain
{
    public class Comment
    {
        [Key]
        [Column("CommentId")]
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime CreatedTime { get; set; }

        public bool IsReply { get; set; }

        public ICollection<Comment> ReplyComments { get; set; }

    }
}
