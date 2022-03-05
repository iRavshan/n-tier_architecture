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
        public int SpeakersCount { get; set; }
        public IEnumerable<Speaker> LastSpeakers { get; set; }
    }
}
