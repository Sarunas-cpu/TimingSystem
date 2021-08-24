using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimingSystem.WebApp.Database;
using TimingSystem.WebApp.Database.Entities;
using TimingSystem.WebApp.EntityExtentsions;
using TimingSystem.WebApp.Models;
using TimingSystem.WebApp.Models.PostRequests;
using TimingSystem.WebApp.Services.Interfaces;


namespace TimingSystem.WebApp.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly DatabaseContext _context;

        public TournamentService(DatabaseContext context)
        {
            _context = context;
        }

        //public ICollection<TournamentDto> TournamentData()
        //{
        //    ICollection<TournamentDto> tournaments = _context.Tournaments.Include(tournament => tournament.Times)
        //                                                                 .Include(tournament => tournament.Penalties)
        //                                                                 .ToList<Tournament>().ConvertToDTO();
        //    foreach (TournamentDto tournament in tournaments)
        //    {
        //        TimeSpan TotalTime = TimeSpan.Zero;
        //        foreach (TimeDto t in tournament.Times)
        //        {
        //            TotalTime += t.DriveTime;
        //        }
        //        tournament.TotalTime = TotalTime;
        //    }
        //    return tournaments;
        //}
        //public ICollection<TournamentDto> TournamentData(int? number)
        //{
        //    ICollection<TournamentDto> tournaments = _context.Tournaments.Where(tournament => tournament.ParticipantNr == number).Include(tournament => tournament.Times).Include(tournament => tournament.Penalties).ToList<Tournament>().ConvertToDTO();
        //    Console.WriteLine(tournaments.ToString());
        //    foreach (TournamentDto tournament in tournaments)
        //    {
        //        TimeSpan TotalTime = TimeSpan.Zero;
        //        foreach (TimeDto t in tournament.Times)
        //        {
        //            TotalTime += t.DriveTime;
        //        }
        //        tournament.TotalTime = TotalTime;
        //    }
        //    return tournaments;
        //}

        //public ICollection<TournamentDto> TournamentData(string category)
        //{
        //    ICollection<TournamentDto> tournaments = _context.Tournaments.Where(tournament => tournament.Category.Equals(category)).Include(tournament => tournament.Times).Include(tournament => tournament.Penalties).ToList<Tournament>().ConvertToDTO();
        //    Console.WriteLine(tournaments.ToString());
        //    foreach (TournamentDto tournament in tournaments)
        //    {
        //        TimeSpan TotalTime = TimeSpan.Zero;
        //        foreach (TimeDto t in tournament.Times)
        //        {
        //            TotalTime += t.DriveTime;
        //        }
        //        tournament.TotalTime = TotalTime;
        //    }
        //    return tournaments;
        //}
        public int PostTime([FromBody] PostTimeRequest postTimeRequest)
        {
            _context.Times.Add(postTimeRequest.ConvertToRequestModel());
            return _context.SaveChanges();
        }

        int ITournamentService.PostTime(PostTimeRequest postTimeRequest)
        {
            throw new NotImplementedException();
        }

        ICollection<TournamentDto> ITournamentService.TournamentData()
        {
            var tournamentId = _context.Tournaments.FirstOrDefault()?.Id;

            if(!tournamentId.HasValue)
            {
                throw new Exception("Tournament does not exists");
            }

            var tournamentData = _context.Tournaments.Include(x => x.Participants)
                .ThenInclude(x => x.Times)
                .Where(x => x.Id == tournamentId)
                .Select(x => x.Participants)
                .FirstOrDefault();

            var data = tournamentData.Select(x => new TournamentDto
            {
                ParticipantFirstName = x.ParticipantFirstName,
                ParticipantLastName = x.ParticipantLastName,
                Category = x.Category,
                ParticipantNr = x.ParticipantNr,
                Times = x.Times.ConvertToDTO(),
                TotalTime = TimeSpan.FromMilliseconds(x.Times.Sum(y => y.DriveTime.TotalMilliseconds))
            }).ToList();

            return data;
        }

        ICollection<TournamentDto> ITournamentService.TournamentData(int? number)
        {
            throw new NotImplementedException();
        }

        ICollection<TournamentDto> ITournamentService.TournamentData(string category)
        {
            throw new NotImplementedException();
        }

        IList<Movie> ITournamentService.GetMovies()
        {
            return _context.Movies.ToList();
        }
    }
}
