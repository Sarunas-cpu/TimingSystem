using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TimingSystem.WebApp.Models;
using TimingSystem.WebApp.Models.PostRequests;
using TimingSystem.WebApp.Services.Interfaces;

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
        public ViewResult TournamentData([FromQuery] string category, int? number, string currentCategory, int? currentNumber, string sortOrder = null)
        {
 
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.NumberSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            ICollection<TournamentDto> tournaments;

            if(category == null)
            {
                category = currentCategory;
            }
            ViewBag.CurrentCategory = category;
            if(number == null)
            {
                number = currentNumber;
            }
            ViewBag.CurrentNumber = number;

            if (!String.IsNullOrEmpty(category))
            {
                tournaments = _tournamentService.TournamentData(category);
            }
            else if(number != null)
            {
                tournaments = _tournamentService.TournamentData(number);
            } else
            {

                number = currentNumber;
                tournaments = _tournamentService.TournamentData();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    tournaments = tournaments.OrderByDescending(t => t.ParticipantFirstName).ToList();
                    break;
                case "Date":
                    tournaments = tournaments.OrderBy(t => t.ParticipantNr).ToList();
                    break;
                case "date_desc":
                    tournaments = tournaments.OrderByDescending(t => t.ParticipantNr).ToList();
                    break;
                case "Name":
                    tournaments = tournaments.OrderBy(t => t.ParticipantFirstName).ToList();
                    break;
                default:
                    break;
            }
            return View(tournaments);
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
