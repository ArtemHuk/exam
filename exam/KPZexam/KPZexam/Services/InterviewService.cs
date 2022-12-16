using DBConnector;
using KPZexam.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Dtos;

namespace KPZexam.Services;

public class InterviewService : IInterviewService
{
    private readonly AppDbContext _context;

    public InterviewService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> AddInterview(InterviewDto interviewDto)
    {
        var interview = ToInterview(interviewDto);
        var interviver = await _context.Interviewers.FindAsync(interview.InterviewerId);
        if (interviver is null)
            return -1;

        interview.CreationDate = DateTime.Now;

        interview.Interviewer = interviver;

        var candidate = await _context.Candidates.FindAsync(interviewDto.CandidateId);
        if(candidate is null)
            return -1;

        interview.Candidate = candidate;

        try
        {
            await _context.Interviews.AddAsync(interview);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {

            return -1;
        }

        return interview.Id;
 
    }

    public async Task<List<InterviewDto>> GetInterviews()
    {
        var interviews = await _context.Interviews.ToListAsync();
        return interviews.Select(i => ToInterviewDto(i)).ToList();
    }

    public async Task<List<InterviewDto>> GetInterviewsByDate(DateTime date)
    {
        var interviews = await _context.Interviews
            .Where(i => i.InterviewDate.Year == date.Year
            && i.InterviewDate.Month == date.Month
            && i.InterviewDate.Day == date.Day).ToListAsync();
        return interviews.Select(i => ToInterviewDto(i)).ToList();
    }

    private Interview ToInterview(InterviewDto interviewDto)
    {
        return new Interview()
        {
            Id = interviewDto.Id,
            CreationDate = interviewDto.CreationDate,
            CandidateId = interviewDto.CandidateId,
            InterviewerId = interviewDto.InterviewerId,
            InterviewDate = interviewDto.InterviewDate,

        };
    }

    private InterviewDto ToInterviewDto(Interview interview) 
    {
        return new InterviewDto()
        {
            Id = interview.Id,
            CreationDate = interview.CreationDate,
            CandidateId = interview.CandidateId,
            InterviewerId = interview.InterviewerId,
            InterviewDate = interview.InterviewDate,
        };
    }
}
