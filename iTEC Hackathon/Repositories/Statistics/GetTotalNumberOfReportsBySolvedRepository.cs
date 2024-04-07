using iTEC_Hackathon.DTOs.Statistics;
using iTEC_Hackathon.Interfaces;
using Dapper;
using System.Data;



namespace iTEC_Hackathon.Repositories
{
    public class GetTotalNumberOfReportsBySolvedRepository : IGetTotalNumberOfReportsBySolvedRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public GetTotalNumberOfReportsBySolvedRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<GetTotalNumberOfReportsBySolvedDTO>> GetTotalNumberOfReportsBySolvedAsyncRepo()
        {
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<GetTotalNumberOfReportsBySolvedDTO>("GetTotalNumberOfReportsBySolved", commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
