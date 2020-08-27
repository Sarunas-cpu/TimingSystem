using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TimingSystem.WebApp.Database.Entities;

namespace TimingSystem.WebApp.Models
{
    public class TimeDto
    {
        [Required]
        public int TimeId { get; set; }
        [Required]
        public TimeSpan DriveTime { get; set; }
        [Required]
        public int TournamentId { get; set; }
    }
}
