using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimingSystem.WebApp.Database;
using TimingSystem.WebApp.Database.Entities;
using TimingSystem.WebApp.EntityExtentsions;
using TimingSystem.WebApp.Models;
using TimingSystem.WebApp.Models.PostRequests;
using TimingSystem.WebApp.Services;

namespace TimingSystem.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {

        private readonly ITournamentService _tournamentService;

        public ValuesController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }
        [HttpGet]
        [Route("{category?}")]
        public ViewResult TournamentData([FromQuery] string category, int? number)
        {
            ICollection<TournamentDto> tournaments;

            if (!String.IsNullOrEmpty(category))
            {
                tournaments = _tournamentService.TournamentData(category);
            }
            else if(number != null)
            {
                tournaments = _tournamentService.TournamentData(number);
            } else
            {
                tournaments = _tournamentService.TournamentData();
            }

            return View(tournaments.ToList());
        }

        [HttpGet]
        [Route("Tournament/Number/{number}")]
        public ActionResult TournamentData(int number = 5)
        {
            ICollection<TournamentDto> tournaments = _tournamentService.TournamentData(number);

            if (tournaments == null)
            {
                return NotFound();
            }
            return View(tournaments);
        }

 /*       [HttpGet]
        [Route("Tournament/Category/{category}")]
        public ActionResult TournamentData(string category)
        {
            ICollection<TournamentDto> tournaments = _tournamentService.TournamentData(category);

            if (tournaments == null)
            {
                return NotFound();
            }
            return View(tournaments);
        }*/

        [HttpPost]
        public ActionResult PostTime([FromBody] PostTimeRequest postTimeRequest)
        {
           int result = _tournamentService.PostTime(postTimeRequest);
            return Ok(result);
        }
 /*       [HttpPost]
        [Route("Tournament/Participant")]
        public async Task<ActionResult<PostTournamentRequest>> PostTournament(PostTournamentRequest postTournamentRequest)
        {
            _context.Tournaments.Add(postTournamentRequest.ConvertToRequestModel());
            await _context.SaveChangesAsync();
            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(postTournamentRequest), new PostTournamentRequest { }, postTournamentRequest);
        }

        [HttpPost]
        [Route("Penalty")]
        public async Task<ActionResult<PostPenaltyRequest>> PostPenalty([FromBody] PostPenaltyRequest postPenaltyRequest)
        {
            _context.Penalties.Add(postPenaltyRequest.ConvertToRequestModel());
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(postPenaltyRequest), new PostPenaltyRequest { }, postPenaltyRequest);
        }*/


    }
}
