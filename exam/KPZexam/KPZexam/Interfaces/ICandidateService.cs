using Models;

namespace KPZexam.Interfaces;

public interface ICandidateService
{
    Task<List<Candidate>> GetCandidates();
    Task<long> AddCandidate(Candidate candidate);
}
