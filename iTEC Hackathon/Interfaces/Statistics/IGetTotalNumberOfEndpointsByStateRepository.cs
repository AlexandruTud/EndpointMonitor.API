using iTEC_Hackathon.DTOs.Statistics;

namespace iTEC_Hackathon.Interfaces
{
    public interface IGetTotalNumberOfEndpointsByStateRepository
    {
        Task<IEnumerable<GetTotalNumberOfEndpointsByStateDTO>> GetTotalNumberOfEndpointsByStateAsyncRepo();
    }
}