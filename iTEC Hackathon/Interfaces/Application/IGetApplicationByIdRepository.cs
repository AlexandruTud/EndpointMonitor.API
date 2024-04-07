using iTEC_Hackathon.DTOs.Application;

namespace iTEC_Hackathon.Interfaces.Application
{
    public interface IGetApplicationByIdRepository
    {
        Task<IEnumerable<ApplicationGetByIdDTO>> GetApplicationByIdAsyncRepo(int idApplication);
    }
}