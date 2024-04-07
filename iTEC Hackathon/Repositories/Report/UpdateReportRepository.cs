using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.DTOs.Report;
using System.Data;
using Dapper;
using iTEC_Hackathon.Interfaces.Report;

namespace iTEC_Hackathon.Repositories.Report
{
    public class UpdateReportRepository : IUpdateReportRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public UpdateReportRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> UpdateReportAsyncRepo(ReportUpdateDTO reportUpdateDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdApplicationReport", reportUpdateDTO.IdApplicationReport);
            parameters.Add("@MarkedAsSolved", reportUpdateDTO.MarkedAsSolved);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("UpdateReportAsSolved", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");

                return result;
            }
        }
    }
}
