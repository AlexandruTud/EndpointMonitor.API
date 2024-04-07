using iTEC_Hackathon.DTOs.Application;

namespace iTEC_Hackathon.Interfaces.User
{
    public interface IUpdateApplicationRepository
    {
        Task<int> UpdateApplicationAsyncRepo(ApplicationUpdateDTO applicationUpdateDTO);
    }
}