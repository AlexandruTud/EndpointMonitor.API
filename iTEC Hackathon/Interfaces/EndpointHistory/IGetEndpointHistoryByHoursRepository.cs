using iTEC_Hackathon.DTOs.EndpointHistory;

namespace iTEC_Hackathon.Interfaces.EndpointHistory
{
    public interface IGetEndpointHistoryByHoursRepository
    {
        Task<IEnumerable<EndpointHistoryGetByHoursDTO>> GetEndpointHistoryByHoursAsyncRepo(int idEndpoint, int hours);
    }
}