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

        public static TimeDto ConvertToDTO(this Time time)
        {
            return new TimeDto
            {
                Heat = time.Heat,
                DriveTime = time.DriveTime,
                PenaltyDescription = time.PenaltyDescription,
                PenaltyDuration = time.PenaltyDuration
            };
        }
        public static ICollection<TimeDto> ConvertToDTO(this ICollection<Time> times)
        {
            return times.Select(time => time.ConvertToDTO()).ToList();
        }

        public static ParticipantsDto ConvertToDTO(this Participants participants)
        {
            TimeSpan TotalTime = TimeSpan.Zero;
            foreach (Time t in participants.Times)
            {
                TotalTime += t.DriveTime;
            }
            return new ParticipantsDto
            {
                ParticipantFirstName = participants.ParticipantFirstName,
                ParticipantLastName = participants.ParticipantLastName,
                Category = participants.Category,
                ParticipantNr = participants.ParticipantNr,
                TotalTime = TotalTime            
            };
        }

        public static ICollection<ParticipantsDto> ConvertToDTO(this ICollection<Participants> participants)
        {
            return participants.Select(participant => participant.ConvertToDTO()).ToList();
        }
        public static TournamentDto ConvertToDTO(this Tournament tournament)
        {
            return new TournamentDto
            {
                Name = tournament.Name,
                Participants = tournament.Participants.ConvertToDTO(),
            };
        }
        public static ICollection<TournamentDto> ConvertToDTO(this ICollection<Tournament> tournaments)
        {
            return tournaments.Select(tournament => tournament.ConvertToDTO()).ToList();
        }
    }
}
