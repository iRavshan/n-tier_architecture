using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.ViewModel
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public User User { get; set; }

        public Content Content { get; set; }

        public DateTime CreatedTime { get; set; }

        public bool IsReply { get; set; }

        public static explicit operator CommentViewModel(Comment comment)
        {
            return new CommentViewModel
            {
                Id = comment.Id,
                Text = comment.Text,
                CreatedTime = comment.CreatedTime,
                IsReply = comment.IsReply
            };
        }

        public static explicit operator Comment(CommentViewModel model)
        {
            return new Comment
            {
                Id = model.Id,
                Text = model.Text,
                CreatedTime = DateTime.Now,
                IsReply = model.IsReply
            };
        }
    }
}
