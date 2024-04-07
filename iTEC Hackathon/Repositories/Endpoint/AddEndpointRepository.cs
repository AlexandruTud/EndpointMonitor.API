using Dapper;
using System.Data;
using iTEC_Hackathon.DTOs.Endpoint;
using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.Interfaces.Endpoint;

namespace iTEC_Hackathon.Repositories.Endpoint
{
    public class AddEndpointRepository : IAddEndpointRepository
    {
        private readonly IDbConnectionFactory _dbconnectionFactory;
        public AddEndpointRepository(IDbConnectionFactory dbconnectionFactory)
        {
            _dbconnectionFactory = dbconnectionFactory;
        }

        public async Task<int> AddEndpointAsyncRepo(EndpointInsertDTO endpointInsertDTO)
        {
            var parameters = new DynamicParameters();

            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            parameters.Add("@URL", endpointInsertDTO.URL);
            parameters.Add("@IdType", endpointInsertDTO.IdType);
            parameters.Add("@DateCreated", sqlFormattedDate);
            parameters.Add("@IdApplication", endpointInsertDTO.IdApplication);
            parameters.Add("@IdEndpoint", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var connection = _dbconnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("InsertEndpoint", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("IdEndpoint");
                return result;
            }
        }
    }
}
