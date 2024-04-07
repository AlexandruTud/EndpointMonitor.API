using Dapper;
using System.Data;
using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.DTOs.Report;
using iTEC_Hackathon.Interfaces.Report;

namespace iTEC_Hackathon.Repositories.Report
{
    public class GetReportRepository : IGetReportRepository
    {
        private readonly IDbConnectionFactory _dbconnectionFactory;
        public GetReportRepository(IDbConnectionFactory dbconnectionFactory)
        {
            _dbconnectionFactory = dbconnectionFactory;
        }

        public async Task<IEnumerable<ReportGetDTO>> GetReportAsyncRepo(int idApplication)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdApplication", idApplication);
            using (var connection = _dbconnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<ReportGetDTO>("GetReportsByApplicationId", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
