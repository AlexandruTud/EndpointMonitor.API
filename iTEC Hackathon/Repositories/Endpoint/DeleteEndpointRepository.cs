using Dapper;
using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.Interfaces.Endpoint;
using System.Data;

namespace iTEC_Hackathon.Repositories.Endpoint
{
    public class DeleteEndpointRepository : IDeleteEndpointRepository
    {
        private readonly IDbConnectionFactory _dbconnectionFactory;
        public DeleteEndpointRepository(IDbConnectionFactory dbconnectionFactory)
        {
            _dbconnectionFactory = dbconnectionFactory;
        }

        public async Task<int> DeleteEndpointAsyncRepo(int idEndpoint)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdEndpoint", idEndpoint);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var connection = _dbconnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("DeleteEndpoint", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
    }
}
