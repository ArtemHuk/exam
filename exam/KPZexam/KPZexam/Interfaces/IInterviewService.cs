using Models.Dtos;

namespace KPZexam.Interfaces
{
    public interface IInterviewService
    {
        Task<long> AddInterview(InterviewDto interviewDto);
        Task<List<InterviewDto>> GetInterviews();
        Task<List<InterviewDto>> GetInterviewsByDate(DateTime date);   
    }
}
