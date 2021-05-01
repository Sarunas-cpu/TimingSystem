using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimingSystem.WebApp.Models
{
    public class ParticipantsDto
    {
        public string ParticipantFirstName { get; set; }
        public string ParticipantLastName { get; set; }
        public int ParticipantNr { get; set; }
        public string Category { get; set; }
        public ICollection<TimeDto> Times { get; set; }
        public TimeSpan TotalTime { get; set; }
    }
}
