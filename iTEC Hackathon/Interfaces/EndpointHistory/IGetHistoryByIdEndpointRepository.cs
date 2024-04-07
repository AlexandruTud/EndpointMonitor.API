using iTEC_Hackathon.DTOs.EndpointHistory;

namespace iTEC_Hackathon.Interfaces
{
    public interface IGetHistoryByIdEndpointRepository
    {
        Task<IEnumerable<EndpointHistoryGetByIdEndpointDTO>> GetHistoryByIdEndpointAsynRepo(int idEndpoint);
    }
}