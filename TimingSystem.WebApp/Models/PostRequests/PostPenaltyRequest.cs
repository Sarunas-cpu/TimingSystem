using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimingSystem.WebApp.Models.PostRequests
{
    public class PostPenaltyRequest
    {
        public string Description { get; set; }
        public int TournamentId { get; set; }
    }
}
