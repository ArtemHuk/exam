using KPZexam.Interfaces;
using KPZexam.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace KPZexam.Controllers
{
    [Route("api/interviewers")]
    [ApiController]
    public class InterviewerController : ControllerBase
    {
        private readonly IInterviewerService _interviewerService;

        public InterviewerController(IInterviewerService interviewerService)
        {
            _interviewerService = interviewerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInterviewers()
        {
            var interviewers = await _interviewerService.GetInterviewers();
            if (interviewers is null) return BadRequest();

            if (interviewers.Count == 0) return NotFound();

            return Ok(interviewers);
        }

        [HttpPost]
        public async Task<IActionResult> AddInterviewer([FromBody] Interviewer interviewer)
        {
            var id = await _interviewerService.AddInterviewer(interviewer);
            if (id == -1) return BadRequest();

            return Ok(id);
        }
    }
}
