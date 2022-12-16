using DBConnector;
using KPZexam.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace KPZexam.Services;

public class CandidateService : ICandidateService
{
    private readonly AppDbContext _context;
    public CandidateService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<long> AddCandidate(Candidate candidate)
    {
        try
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {

            return -1;
        }
        
        return candidate.Id;
    }

    public async Task<List<Candidate>> GetCandidates()
    {
        return await _context.Candidates.ToListAsync();
    }
}
