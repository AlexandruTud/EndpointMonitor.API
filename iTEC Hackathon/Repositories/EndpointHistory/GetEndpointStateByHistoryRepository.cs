using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using iTEC_Hackathon.DTOs.EndpointHistory;
using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.Interfaces.EndpointHistory;

namespace iTEC_Hackathon.Repositories.EndpointHistory
{
    public class GetEndpointStateByHistoryRepository : IGetEndpointStateByHistoryRepository
    {
        private readonly IDbConnectionFactory _dbconnectionFactory;
        public GetEndpointStateByHistoryRepository(IDbConnectionFactory dbconnectionFactory)
        {
            _dbconnectionFactory = dbconnectionFactory;
        }   

        public async Task<IEnumerable<EndpointHistoryGetEndpointsStateDTO>> GetEndpointStateByHistoryAsyncRepo(int idApplication)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@IdApplication", idApplication);

            using(var connection = _dbconnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<EndpointHistoryGetEndpointsStateDTO>("GetEndpointStateByHistory", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
