using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimingSystem.WebApp.Database.Entities;

namespace TimingSystem.WebApp.Models.PostRequests
{
    public class PostTimeRequest
    {
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Milliseconds { get; set; }
        public int TournamentRefId { get; set; }
    }
}
