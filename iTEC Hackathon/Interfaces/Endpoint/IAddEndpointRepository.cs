using iTEC_Hackathon.DTOs.Endpoint;

namespace iTEC_Hackathon.Interfaces.Endpoint
{
    public interface IAddEndpointRepository
    {
        Task<int> AddEndpointAsyncRepo(EndpointInsertDTO endpoint);
    }
}