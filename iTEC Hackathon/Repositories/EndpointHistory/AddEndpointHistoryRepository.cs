using Dapper;
using System.Data;
using iTEC_Hackathon.DTOs.EndpointHistory;
using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.Interfaces.EndpointHistory;



namespace iTEC_Hackathon.Repositories.EndpointHistory
{
    public class AddEndpointHistoryRepository : IAddEndpointHistoryRepository
    {
        private readonly IDbConnectionFactory _dbconnectionFactory;
        public AddEndpointHistoryRepository(IDbConnectionFactory dbconnectionFactory)
        {
            _dbconnectionFactory = dbconnectionFactory;
        }
        
        public async Task<int> AddEndpointHistoryAsyncRepo(EndpointHistoryInsertDTO endpointHistoryInsertDTO)
        {
            var parameters = new DynamicParameters();

            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            parameters.Add("@IdEndpoint", endpointHistoryInsertDTO.IdEndpoint);
            parameters.Add("@IdUser", endpointHistoryInsertDTO.IdUser);
            parameters.Add("@Code", endpointHistoryInsertDTO.Code);
            parameters.Add("@Mentions", endpointHistoryInsertDTO.Mentions);
            parameters.Add("@DateCreated", sqlFormattedDate);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var connection = _dbconnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("InsertEndpointHistory", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }   
    }
}
