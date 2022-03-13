using Microsoft.AspNetCore.Http;
using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.ViewModel
{
    public class SpeakerViewModel
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Job { get; set; }
        public string PhotoUrl { get; set; }
        public string Quote { get; set; }
        public DateTime CreateTime { get; set; }

        public static explicit operator SpeakerViewModel(Speaker model)
        {
            return new SpeakerViewModel
            {
                Id = model.Id,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Job = model.Job,
                PhotoUrl = model.PhotoUrl,
                Quote = model.Quote,
                CreateTime = model.CreateTime
            };
        }

        public static explicit operator Speaker(SpeakerViewModel model)
        {
            return new Speaker
            {
                Id = model.Id,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Job = model.Job,
                Quote = model.Quote,
                PhotoUrl = model.PhotoUrl,
                CreateTime = DateTime.Now
            };
        }
    }
}
