using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimingSystem.WebApp.Database.Entities;
using TimingSystem.WebApp.Models.PostRequests;

namespace TimingSystem.WebApp.EntityExtentsions
{
    public static class MapRequestModels
    {
        public static Time ConvertToRequestModel(this PostTimeRequest postTimeRequest)
        {
            return new Time
            {
                DriveTime = new TimeSpan (postTimeRequest.Days, postTimeRequest.Hours, postTimeRequest.Minutes, postTimeRequest.Seconds, postTimeRequest.Milliseconds),              
                TournamentId = postTimeRequest.TournamentId
            };
        }

        public static Penalty ConvertToRequestModel(this PostPenaltyRequest postTimeRequest)
        {
            return new Penalty
            {
                Description = postTimeRequest.Description,
                TournamentId = postTimeRequest.TournamentId
            };
        }

        public static Tournament ConvertToRequestModel(this PostTournamentRequest postTournamentRequest)
        {
            return new Tournament
            {
                ParticipantFirstName = postTournamentRequest.ParticipantFirstName,
                ParticipantLastName = postTournamentRequest.ParticipantLastName,
                Category = postTournamentRequest.Category,
                ParticipantNr = postTournamentRequest.ParticipantNr,
            };
        }
    }
}
