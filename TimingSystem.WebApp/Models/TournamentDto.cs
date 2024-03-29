﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TimingSystem.WebApp.Database.Entities;

namespace TimingSystem.WebApp.Models
{
    public class TournamentDto
    {
        public string Name { get; set; }
        public ICollection<ParticipantsDto>Participants  { get; set; }
        public string ParticipantFirstName { get; set; }
        public string ParticipantLastName { get; set; }
        public int ParticipantNr { get; set; }
        public string Category { get; set; }
        public ICollection<TimeDto> Times { get; set; }
        public TimeSpan TotalTime { get; set; }
    }
}
