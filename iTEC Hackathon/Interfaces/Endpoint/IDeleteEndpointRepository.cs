namespace iTEC_Hackathon.Interfaces.Endpoint
{
    public interface IDeleteEndpointRepository
    {
        Task<int> DeleteEndpointAsyncRepo(int idEndpoint);
    }
}