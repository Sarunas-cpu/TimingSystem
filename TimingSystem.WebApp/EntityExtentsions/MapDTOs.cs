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
        public static ICollection<PenaltyDto> ConvertToDTO(this ICollection<Penalty> penalties)
        {
            return penalties.Select(penalty => penalty.ConvertToDTO()).ToList() ;
        }

        public static TimeDto ConvertToDTO(this Time time)
        {
            return new TimeDto
            {
                TimeId = time.TimeId,
                DriveTime = time.DriveTime,
            };
        }
        public static ICollection<TimeDto> ConvertToDTO(this ICollection<Time> times)
        {
            return times.Select(time => time.ConvertToDTO()).ToList();
        }
        public static TournamentDto ConvertToDTO(this Tournament tournament)
        {
/*            TimeSpan TotalTime = TimeSpan.Zero;
            foreach (Time t in tournament.Times)
            {
                TotalTime += t.DriveTime;
            }*/
            return new TournamentDto
            {
                TournamentId = tournament.TournamentId,
                ParticipantFirstName = tournament.ParticipantFirstName,
                ParticipantLastName = tournament.ParticipantLastName,
                ParticipantNr = tournament.ParticipantNr,
                Category = tournament.Category,
                Times = tournament.Times.ConvertToDTO(),
                Penalties = tournament.Penalties.ConvertToDTO(),
                TotalTime = TimeSpan.Zero
            };
        }
        public static ICollection<TournamentDto> ConvertToDTO(this ICollection<Tournament> tournaments)
        {
            return tournaments.Select(tournament => tournament.ConvertToDTO()).ToList();
        }
    }
}
