using Dapper;
using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.Interfaces.Report;
using System.Data;

namespace iTEC_Hackathon.Repositories.Report
{
    public class DeleteReportRepository : IDeleteReportRepository
    {
        private readonly IDbConnectionFactory _dbconnectionFactory;
        public DeleteReportRepository(IDbConnectionFactory dbconnectionFactory)
        {
            _dbconnectionFactory = dbconnectionFactory;
        }

        public async Task<int> DeleteReportAsyncRepo(int idReport)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdApplicationReport", idReport);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var connection = _dbconnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("DeleteReport", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
    }
}
