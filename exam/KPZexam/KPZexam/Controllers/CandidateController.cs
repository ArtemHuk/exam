using DBConnector;
using KPZexam.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace KPZexam.Controllers
{
    [Route("api/candidates")]
    [ApiController]
    public class CandidateController : ControllerBase
    {

        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCandidates()
        {
            var candidates = await _candidateService.GetCandidates();
            if (candidates is null) return BadRequest();

            if(candidates.Count== 0) return NotFound();

            return Ok(candidates);
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidate([FromBody] Candidate candidate)
        {
            var id = await _candidateService.AddCandidate(candidate);
            if(id == -1) return BadRequest();

            return Ok(id);
        }
    }
}
