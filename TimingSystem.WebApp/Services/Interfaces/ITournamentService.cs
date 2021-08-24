using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TimingSystem.WebApp.Database.Entities;
using TimingSystem.WebApp.Models;
using TimingSystem.WebApp.Models.PostRequests;


namespace TimingSystem.WebApp.Services.Interfaces
{
    public interface ITournamentService
    {
        public ICollection<TournamentDto> TournamentData();
        public int PostTime([FromBody] PostTimeRequest postTimeRequest);

        public ICollection<TournamentDto> TournamentData(int? number);
        public ICollection<TournamentDto> TournamentData(string category);

        public IList<Movie> GetMovies();
    }
}
