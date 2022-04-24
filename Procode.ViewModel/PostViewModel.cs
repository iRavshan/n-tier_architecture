using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.ViewModel
{
    public class PostViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Text { get; set; }

        public string Tags { get; set; }

        public string AuthorUsername { get; set; }

        public User User { get; set; }

        public DateTime CreatedTime { get; set; }

        public static explicit operator PostViewModel(Post post)
        {
            return new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                ShortDescription = post.ShortDescription,
                Text = post.Text,
                Tags = post.Tags,
                AuthorUsername = post.AuthorUsername,
                User = post.User,
                CreatedTime = post.CreatedTime
            };
        }

        public static explicit operator Post(PostViewModel post)
        {
            return new Post
            {
                Id = post.Id,
                Title = post.Title,
                ShortDescription = post.ShortDescription,
                Text = post.Text,
                Tags = post.Tags,
                AuthorUsername = post.AuthorUsername,
                User = post.User,
                CreatedTime = post.CreatedTime
            };
        }
    }
}
