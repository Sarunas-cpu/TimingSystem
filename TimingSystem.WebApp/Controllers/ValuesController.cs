using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimingSystem.WebApp.Database;
using TimingSystem.WebApp.Database.Entities;
using TimingSystem.WebApp.EntityExtentsions;
using TimingSystem.WebApp.Models.PostRequests;

namespace TimingSystem.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly DatabaseContext _context;

        public ValuesController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Data([FromQuery] string vardas)
        {
            return Ok(vardas);
        }

        [HttpPost]
        public async Task<ActionResult<PostTimeRequest>> PostParticipant([FromBody] PostTimeRequest postTimeRequest)
        {
            _context.Times.Add(postTimeRequest.ConvertToRequestModel());
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(postTimeRequest), new PostTimeRequest { TournamentRefId = postTimeRequest.TournamentRefId }, postTimeRequest);
        }
    [HttpPost]
        [Route("Tournament/{tournament?}")]
        public async Task<ActionResult<PostTournamentRequest>> PostTournament(PostTournamentRequest postTournamentRequest)
    {
        _context.Tournaments.Add(postTournamentRequest.ConvertToRequestModel());
        await _context.SaveChangesAsync();

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(postTournamentRequest), new PostTournamentRequest {}, postTournamentRequest);
    }

        [HttpPost]
        [Route("Penalty")]
        public async Task<ActionResult<PostPenaltyRequest>> PostPenalty([FromBody] PostPenaltyRequest postPenaltyRequest)
        {
            _context.Penalties.Add(postPenaltyRequest.ConvertToRequestModel());
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(postPenaltyRequest), new PostPenaltyRequest { }, postPenaltyRequest);
        }


    }
}
