using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimingSystem.WebApp.Models.PostRequests;
using TimingSystem.WebApp.Services.Interfaces;

namespace TimingSystem.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public MoviesController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        // GET api/values
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var movies = _tournamentService.GetMovies();

                return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong: {ex.Message}");
            }
        }

        //[HttpPost]
        //public ActionResult PostTime([FromBody] PostTimeRequest postTimeRequest)
        //{
        //    postTimeRequest = new PostTimeRequest();
        //    postTimeRequest.Days = 0;
        //    postTimeRequest.Hours = 0;
        //    postTimeRequest.Milliseconds = 10;
        //    postTimeRequest.Minutes = 50;
        //    postTimeRequest.Seconds = 2;
        //    postTimeRequest.TournamentId = 1;


        //    int result = _tournamentService.PostTime(postTimeRequest);
        //    return Ok(result);
        //}

        [HttpPost]
        public IActionResult PostTime([FromBody] PostTimeRequest postTimeRequest)
        {
            postTimeRequest = new PostTimeRequest();
            postTimeRequest.Days = 0;
            postTimeRequest.Hours = 0;
            postTimeRequest.Milliseconds = 10;
            postTimeRequest.Minutes = 50;
            postTimeRequest.Seconds = 2;
            postTimeRequest.TournamentId = 1;


            int result = _tournamentService.PostTime(postTimeRequest);
            return Ok(result);
        }
    }
}
