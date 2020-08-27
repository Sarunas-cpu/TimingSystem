using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TimingSystem.WebApp.Database.Entities;

namespace TimingSystem.WebApp.Models
{
    public class TournamentDto
    {
        [Required]
        public int TournamentId { get; set; }
        [Required]
        public string ParticipantFirstName { get; set; }
        [Required]
        public string ParticipantLastName { get; set; }
        [Required]
        public int ParticipantNr { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public IEnumerable<Time> Times { get; set; }
        [Required]
        public IEnumerable<Penalty> Penalties { get; set; }
    }
}
