using iTEC_Hackathon.DTOs.Endpoint;
using iTEC_Hackathon.DTOs.EndpointHistory;

namespace iTEC_Hackathon.Interfaces.Endpoint
{
    public interface IGetEndpointRepository
    {
        Task<IEnumerable<EndpointGetDTO>> GetEndpointAsyncRepo(int idApplication);
    }
}