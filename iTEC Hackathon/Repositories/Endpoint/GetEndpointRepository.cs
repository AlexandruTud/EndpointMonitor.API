using System.Data;
using Dapper;
using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.DTOs.Endpoint;
using iTEC_Hackathon.Interfaces.Endpoint;
using iTEC_Hackathon.DTOs.EndpointHistory;

namespace iTEC_Hackathon.Repositories
{
    public class GetEndpointRepository : IGetEndpointRepository
    {
        private readonly IDbConnectionFactory _dbconnectionFactory;
        public GetEndpointRepository(IDbConnectionFactory dbconnectionFactory)
        {
            _dbconnectionFactory = dbconnectionFactory;
        }

        public async Task<IEnumerable<EndpointGetDTO>> GetEndpointAsyncRepo(int idApplication)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdApplication", idApplication);
            using (var connection = _dbconnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<EndpointGetDTO>("GetEndpointsByApplicationId", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
