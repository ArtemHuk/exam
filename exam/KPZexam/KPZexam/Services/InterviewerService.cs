using DBConnector;
using KPZexam.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace KPZexam.Services;

public class InterviewerService : IInterviewerService
{
    private readonly AppDbContext _context;

    public InterviewerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> AddInterviewer(Interviewer interviewer)
    {
        try
        {
            await _context.Interviewers.AddAsync(interviewer);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {

            return -1;
        }

        return interviewer.Id;
    }

    public async Task<List<Interviewer>> GetInterviewers()
    {
        return await _context.Interviewers.ToListAsync();
    }
}
