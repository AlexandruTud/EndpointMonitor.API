using Dapper;
using System.Data;
using iTEC_Hackathon.DTOs.Report;
using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.Interfaces.Report;

namespace iTEC_Hackathon.Repositories.Report
{
    public class AddReportRepository : IAddReportRepository
    {
        private readonly IDbConnectionFactory _dbconnectionFactory;
        public AddReportRepository(IDbConnectionFactory dbconnectionFactory)
        {
            _dbconnectionFactory = dbconnectionFactory;
        }

        public async Task<int> AddReportAsyncRepo(ReportInsertDTO reportInsertDTO)
        {
            var parameters = new DynamicParameters();

            DateTime myDateTime = DateTime.Now;
            

            parameters.Add("@IdApplication", reportInsertDTO.IdApplication);
            parameters.Add("@IdEndpoint", reportInsertDTO.IdEndpoint);
            parameters.Add("@IdUser", reportInsertDTO.IdUser);
            parameters.Add("@DateCreated", myDateTime);
            parameters.Add("@Mentions", reportInsertDTO.Mentions);
            parameters.Add("@MarkedAsSolved", 0);
            parameters.Add("@IdApplicationReport", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var connection = _dbconnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("InsertReport", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("IdApplicationReport");
                return result;
            }
        }
    }
}
