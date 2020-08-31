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


namespace TimingSystem.WebApp.Services
{
    public interface ITournamentService
    {
        public ICollection<TournamentDto> TournamentData();
        public int PostTime([FromBody] PostTimeRequest postTimeRequest);

        public ICollection<TournamentDto> TournamentData(int? number);
        public ICollection<TournamentDto> TournamentData(string category);
    }
    public class TournamentService : ITournamentService
    {
        private readonly DatabaseContext _context;

        public TournamentService(DatabaseContext context)
        {
            _context = context;
        }

        public ICollection<TournamentDto> TournamentData()
        {
            ICollection<TournamentDto> tournaments = _context.Tournaments.Include(tournament => tournament.Times).Include(tournament => tournament.Penalties).ToList<Tournament>().ConvertToDTO();
            foreach (TournamentDto tournament in tournaments)
            {
            TimeSpan TotalTime = TimeSpan.Zero;
                foreach (TimeDto t in tournament.Times)
                {
                    TotalTime += t.DriveTime;
                }
                tournament.TotalTime = TotalTime;
            }
            return tournaments;
        }
        public ICollection<TournamentDto> TournamentData(int? number)
        {
            ICollection<TournamentDto> tournaments = _context.Tournaments.Where(tournament => tournament.ParticipantNr == number).Include(tournament => tournament.Times).Include(tournament => tournament.Penalties).ToList<Tournament>().ConvertToDTO();
            Console.WriteLine(tournaments.ToString());
            foreach (TournamentDto tournament in tournaments)
            {
                TimeSpan TotalTime = TimeSpan.Zero;
                foreach (TimeDto t in tournament.Times)
                {
                    TotalTime += t.DriveTime;
                }
                tournament.TotalTime = TotalTime;
            }
            return tournaments;
        }

        public ICollection<TournamentDto> TournamentData(string category)
        {
            ICollection<TournamentDto> tournaments = _context.Tournaments.Where(tournament => tournament.Category.Equals(category)).Include(tournament => tournament.Times).Include(tournament => tournament.Penalties).ToList<Tournament>().ConvertToDTO();
            Console.WriteLine(tournaments.ToString());
            foreach (TournamentDto tournament in tournaments)
            {
                TimeSpan TotalTime = TimeSpan.Zero;
                foreach (TimeDto t in tournament.Times)
                {
                    TotalTime += t.DriveTime;
                }
                tournament.TotalTime = TotalTime;
            }
            return tournaments;
        }
        public int PostTime([FromBody] PostTimeRequest postTimeRequest)
        {
            _context.Times.Add(postTimeRequest.ConvertToRequestModel());
            return _context.SaveChanges(); 

        }
    }
}
