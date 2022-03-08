using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.ViewModel
{
    public class FeedbackViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Subject { get; set; }
        public string AuthorEmail { get; set; }
        public DateTime CreateTime { get; set; }
        public bool isRead { get; set; }
        public bool isDelete { get; set; }

        public static explicit operator FeedbackViewModel(Feedback feedback)
        {
            return new FeedbackViewModel
            {
                Id = feedback.Id,
                Text = feedback.Text,
                Subject = feedback.Subject,
                AuthorEmail = feedback.AuthorEmail,
                isRead = feedback.isRead,
                isDelete = feedback.isDelete
            };
        }

        public static explicit operator Feedback(FeedbackViewModel model)
        {
            return new Feedback
            {
                Id = model.Id,
                Text = model.Text,
                Subject = model.Subject,
                AuthorEmail = model.AuthorEmail,
                CreateTime = DateTime.Now,
                isRead = false,
                isDelete = false
            };
        }
    }
}
