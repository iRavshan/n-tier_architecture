﻿using System;
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

        public string Text { get; set; }

        public User User { get; set; }

        public Content Content { get; set; }

        public DateTime CreatedTime { get; set; }

        public bool IsReply { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}