using Procode.Domain;
using System;

namespace Procode.ViewModel
{
    public class ContentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AuthorFirstname { get; set; }
        public string AuthorLastname { get; set; }
        public string ShortDescription { get; set; }
        public string ThumbnailUrl { get; set; }
        public string VideoUrl { get; set; }
        public string GitUrl { get; set; }

        public static explicit operator ContentViewModel(Content content)
        {
            return new ContentViewModel
            {
                Id = content.Id,
                Name = content.Name,
                AuthorFirstname = content.AuthorFirstname,
                AuthorLastname = content.AuthorLastname,
                ShortDescription = content.ShortDescription,
                ThumbnailUrl = content.ThumbnailUrl,
                VideoUrl = content.VideoUrl,
                GitUrl = content.GitUrl
            };
        }

        public static explicit operator Content(ContentViewModel content)
        {
            return new Content
            {
                Id = content.Id,
                Name = content.Name,
                AuthorFirstname = content.AuthorFirstname,
                AuthorLastname = content.AuthorLastname,
                ShortDescription = content.ShortDescription,
                ThumbnailUrl = content.ThumbnailUrl,
                VideoUrl = content.VideoUrl,
                GitUrl = content.GitUrl,
                CreateTime = DateTime.Now
            };
        }
    }
}
