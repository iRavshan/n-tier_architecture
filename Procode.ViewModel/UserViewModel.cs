using Microsoft.AspNetCore.Identity;
using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.ViewModel
{
    public class UserViewModel : IdentityUser
    {
        public DateTime RegisteredDateTime { get; set; }

        public string Bio { get; set; }

        public string Company { get; set; }

        public string WebsiteUri { get; set; }

        public string Status { get; set; }

        public string Location { get; set; }

        public bool DisplayEmail { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public static explicit operator UserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Comments = user.Comments,
                PasswordHash = user.PasswordHash,
                RegisteredDateTime = user.RegisteredDateTime,
                Bio = user.Bio,
                Company = user.Company,
                WebsiteUri = user.WebsiteUri,
                Status = user.Status,
                Location = user.Location,
                DisplayEmail = user.DisplayEmail
            };
        }

        public static explicit operator User(UserViewModel user)
        {
            return new User
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Comments = user.Comments,
                PasswordHash = user.PasswordHash,
                RegisteredDateTime = DateTime.Now,
                Bio = user.Bio,
                Company = user.Company,
                WebsiteUri = user.WebsiteUri,
                Status = user.Status,
                Location = user.Location,
                DisplayEmail = user.DisplayEmail
            };
        }
    }
}
