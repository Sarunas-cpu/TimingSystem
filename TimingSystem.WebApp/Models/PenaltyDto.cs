using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TimingSystem.WebApp.Database.Entities;

namespace TimingSystem.WebApp.Models
{
    public class PenaltyDto
    {
        [Required]
        public int PenaltyId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int TournamentId { get; set; }
    }
}
