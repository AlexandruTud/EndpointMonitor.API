using iTEC_Hackathon.DTOs.EndpointHistory;

namespace iTEC_Hackathon.Interfaces.EndpointHistory
{
    public interface IAddEndpointHistoryRepository
    {
        Task<int> AddEndpointHistoryAsyncRepo(EndpointHistoryInsertDTO endpointHistoryInsertDTO);
    }
}