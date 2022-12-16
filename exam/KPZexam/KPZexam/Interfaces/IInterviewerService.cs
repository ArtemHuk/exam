using Models;

namespace KPZexam.Interfaces
{
    public interface IInterviewerService
    {
        Task<List<Interviewer>> GetInterviewers();
        Task<long> AddInterviewer(Interviewer interviewer);
    }
}
