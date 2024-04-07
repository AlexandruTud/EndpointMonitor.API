using iTEC_Hackathon.DTOs.EndpointHistory;

namespace iTEC_Hackathon.Interfaces.EndpointHistory
{
    public interface IGetEndpointStateByHistoryRepository
    {
        Task<IEnumerable<EndpointHistoryGetEndpointsStateDTO>> GetEndpointStateByHistoryAsyncRepo(int idApplication);
    }
}