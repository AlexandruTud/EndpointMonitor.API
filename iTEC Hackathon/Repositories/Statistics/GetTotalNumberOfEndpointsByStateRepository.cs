using iTEC_Hackathon.DTOs.Statistics;
using iTEC_Hackathon.Interfaces;
using Dapper;
using System.Data;


namespace iTEC_Hackathon.Repositories.Statistics
{
    public class GetTotalNumberOfEndpointsByStateRepository : IGetTotalNumberOfEndpointsByStateRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public GetTotalNumberOfEndpointsByStateRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<GetTotalNumberOfEndpointsByStateDTO>> GetTotalNumberOfEndpointsByStateAsyncRepo()
        {
            using(var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<GetTotalNumberOfEndpointsByStateDTO>("GetTotalNumberOfEndpointsByState", commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
