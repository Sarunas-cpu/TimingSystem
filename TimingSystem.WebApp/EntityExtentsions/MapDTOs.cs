using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimingSystem.WebApp.Database.Entities;
using TimingSystem.WebApp.Models;

namespace TimingSystem.WebApp.EntityExtentsions
{
    public static class MapDTOs
    {
        public static PenaltyDto ConvertToDTO(this Penalty penalty)
        {
            return new PenaltyDto
            {
                PenaltyId = penalty.PenaltyId,
                Description = penalty.Description,
            };
        }
        public static IEnumerable<PenaltyDto> ConvertToDTO(this IEnumerable<Penalty> penalties)
        {
            return penalties.Select(penalty => penalty.ConvertToDTO()) ;
        }

        public static TimeDto ConvertToDTO(this Time time)
        {
            return new TimeDto
            {
                TimeId = time.TimeId,
                DriveTime = time.DriveTime,
            };
        }
        public static IEnumerable<TimeDto> ConvertToDTO(this IEnumerable<Time> times)
        {
            return times.Select(time => time.ConvertToDTO());
        }
        public static TournamentDto ConvertToDTO(this Tournament tournament)
        {
            TimeSpan TotalTime = TimeSpan.Zero;
            foreach (Time t in tournament.Times)
            {
                TotalTime += t.DriveTime;
            };
            return new TournamentDto
            {
                TournamentId = tournament.TournamentId,
                ParticipantFirstName = tournament.ParticipantFirstName,
                ParticipantLastName = tournament.ParticipantLastName,
                ParticipantNr = tournament.ParticipantNr,
                Category = tournament.Category         
            };
        }
    }
}
