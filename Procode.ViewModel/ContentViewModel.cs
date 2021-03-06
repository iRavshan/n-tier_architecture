using Procode.Domain;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace Procode.ViewModel
{
    public class ContentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AuthorFirstname { get; set; }
        public string AuthorLastname { get; set; }
        public string ShortDescription { get; set; }
        public string Tag { get; set; }
        public string YouTubeVideoID { get; set; }
        public string GitUrl { get; set; }
        public string Text { get; set; }
        public DateTime CreateTime { get; set; }

        public static explicit operator ContentViewModel(Content content)
        {
            return new ContentViewModel
            {
                Id = content.Id,
                Name = content.Name,
                AuthorFirstname = content.AuthorFirstname,
                AuthorLastname = content.AuthorLastname,
                ShortDescription = content.ShortDescription,
                YouTubeVideoID = content.YouTubeVideoID,
                Tag = content.Tag,
                GitUrl = content.GitUrl,
                CreateTime = content.CreateTime,
                Text = content.Text
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
                Tag = content.Tag,
                YouTubeVideoID = content.YouTubeVideoID,
                GitUrl = content.GitUrl,
                CreateTime = DateTime.Now,
                Text = content.Text
            };
        }
    }
}
