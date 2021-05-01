using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimingSystem.WebApp.Database.Entities
{
    public class Participants
    {
        public Participants()
        {
            Times = new List<Time>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string ParticipantFirstName { get; set; }
        public string ParticipantLastName { get; set; }
        public int ParticipantNr { get; set; }
        public string Category { get; set; }
        public ICollection<Time> Times { get; set; }

    }
}
