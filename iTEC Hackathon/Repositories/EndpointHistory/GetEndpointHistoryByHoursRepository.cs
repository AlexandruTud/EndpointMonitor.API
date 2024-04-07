using Dapper;
using iTEC_Hackathon.DTOs.EndpointHistory;
using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.Interfaces.EndpointHistory;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace iTEC_Hackathon.Repositories
{
    public class GetEndpointHistoryByHoursRepository : IGetEndpointHistoryByHoursRepository
    {
        private readonly IDbConnectionFactory _dbconnectionFactory;
        public GetEndpointHistoryByHoursRepository(IDbConnectionFactory dbconnectionFactory)
        {
            _dbconnectionFactory = dbconnectionFactory;
        }

        public async Task<IEnumerable<EndpointHistoryGetByHoursDTO>> GetEndpointHistoryByHoursAsyncRepo([FromQuery] int idEndpoint, [FromQuery] int hours)
        {
            var parameters = new DynamicParameters();

            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            parameters.Add("@IdEndpoint", idEndpoint);
            parameters.Add("@Hours", hours);
            parameters.Add("@TimeNow", sqlFormattedDate);

            using (var connection = _dbconnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<EndpointHistoryGetByHoursDTO>("GetEndpointHistoryByHours", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}