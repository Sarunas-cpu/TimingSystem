using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimingSystem.WebApp.Models.PostRequests
{
    public class PostTournamentRequest
    {
        public string ParticipantFirstName { get; set; }
        public string ParticipantLastName { get; set; }
        public int ParticipantNr { get; set; }
        public string Category { get; set; }
    }
}
