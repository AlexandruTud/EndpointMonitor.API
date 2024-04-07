using Dapper;
using iTEC_Hackathon.DTOs.EndpointHistory;
using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.Interfaces.EndpointHistory;
using System.Data;

namespace iTEC_Hackathon.Repositories
{
    public class GetHistoryByIdEndpointRepository : IGetHistoryByIdEndpointRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public GetHistoryByIdEndpointRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<EndpointHistoryGetByIdEndpointDTO>> GetHistoryByIdEndpointAsynRepo(int idEndpoint)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@IdEndpoint", idEndpoint);

            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<EndpointHistoryGetByIdEndpointDTO>("GetEndpointHistoryById", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
