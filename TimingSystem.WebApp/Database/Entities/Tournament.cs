using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TimingSystem.WebApp.Models;

namespace TimingSystem.WebApp.Database.Entities
{
    public class Tournament
    {
        public Tournament()
        {
            Times = new List<Time>();
            Penalties = new List<Penalty>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TournamentId { get; set; }
        public string ParticipantFirstName { get; set; }
        public string ParticipantLastName { get; set; }
        public int ParticipantNr { get; set; }
        public string Category { get; set; }
        public ICollection<Time> Times { get; set; }
        public ICollection<Penalty> Penalties { get; set; }


    }
}
