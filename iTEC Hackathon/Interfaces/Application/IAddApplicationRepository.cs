using iTEC_Hackathon.DTOs.Application;

namespace iTEC_Hackathon.Interfaces.Application
{
    public interface IAddApplicationRepository
    {
        Task<int> AddApplicationAsyncRepo(ApplicationInsertDTO applicationInsertDTO);
    }
}