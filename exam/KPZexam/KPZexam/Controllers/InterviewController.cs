using KPZexam.Interfaces;
using KPZexam.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dtos;

namespace KPZexam.Controllers
{
    [Route("api/interviews")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewService _interviewService;

        public InterviewController(IInterviewService interviewService)
        {
            _interviewService = interviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInterviews()
        {
            var interviews = await _interviewService.GetInterviews();
            if (interviews is null) return BadRequest();

            if (interviews.Count == 0) return NotFound();

            return Ok(interviews);
        }

        [HttpGet("{date}")]
        public async Task<IActionResult> GetInterviewsByDate(DateTime date)
        {

            var interviews = await _interviewService.GetInterviewsByDate(date);
            if (interviews is null) return BadRequest();

            if (interviews.Count == 0) return NotFound();

            return Ok(interviews);
        }

        [HttpPost]
        public async Task<IActionResult> AddInterview([FromBody] InterviewDto interview)
        {
            var id = await _interviewService.AddInterview(interview);
            if (id == -1) return BadRequest();

            return Ok(id);
        }
    }
}
